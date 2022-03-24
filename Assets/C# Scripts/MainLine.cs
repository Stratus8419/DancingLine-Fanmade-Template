using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MainLine
{
    public class MainLine : MonoBehaviour
    {
        public GameObject CameraBind;
        public float CameraFollowingExtent = 25.0f;
        public Vector3 CameraBindEulerAngles = new Vector3(35, 30, 0);
        public Vector3 CameraBindPosition = Vector3.zero;
        public bool CameraFollow;
        public float FollowingNeedtime;

        public float Speed = 15.0f;

        public AudioSource Song;
        public Rigidbody LineRigidbody;

        public Vector3 TurnAround1 = new Vector3(0, 90, 0), TurnAround2 = new Vector3(0, 0, 0);
        public bool TurnToTA1 = true;

        public GameObject LineTail;
        private GameObject nowTail;

        public bool Invincible = false;
        public AudioClip DieAudioN;
        public GameObject DieEffect;

        private bool nowPlaying = false;
        private bool isOver = false;


        void TurnBlock()
        {
            if(TurnToTA1)
            {
                transform.localEulerAngles = TurnAround2;
                TurnToTA1 = false;
            }
            else
            {
                transform.localEulerAngles = TurnAround1;
                TurnToTA1 = true;
            }
            nowTail = Instantiate(LineTail, transform.position, transform.rotation);
        }

        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y / 2 + 0.1f);
        }

        bool Click()
        {
            return (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space));
        }

        //Start函数在第一帧调用
        void Start()
        {
            Song.Stop();
            nowPlaying = false;
            isOver = false;

            if(TurnToTA1)
            {
                transform.localEulerAngles = TurnAround1;
            }
            else
            {
                transform.localEulerAngles = TurnAround2;
            }

            CameraBind.transform.eulerAngles = CameraBindEulerAngles;
            CameraBind.transform.localScale = new Vector3(CameraFollowingExtent, CameraFollowingExtent, CameraFollowingExtent);
        }

        //Update函数每帧调用一次
        void Update()
        {
            if(nowPlaying && !isOver)
            {
                transform.Translate(0, 0, Time.deltaTime * Speed);

                if(IsGrounded())
                {
                    if(nowTail == null)
                    {
                        nowTail = Instantiate(LineTail, transform.position, transform.rotation);
                    }
                    else
                    {
                        nowTail.transform.Translate(0, 0, (Time.deltaTime / 2 * Speed));
                        nowTail.transform.localScale += new Vector3(0, 0, (Time.deltaTime * Speed));
                    }

                    if(Click())
                    {
                        TurnBlock();
                    }
                }
                else
                {
                    if(nowTail != null)
                    {
                        nowTail = null;
                    }
                }

                if(CameraFollow)
                {
                    CameraBind.transform.DOMove(transform.position + CameraBindPosition, FollowingNeedtime);
                }
            }
            else if(Click())
            {
                nowPlaying = true;
                nowTail = Instantiate(LineTail, transform.position, transform.rotation);
                Song.Play();
            }
            else if(isOver)
            {
                if(Song.volume > 0)
                {
                    Song.volume -= 0.3f * Time.deltaTime;
                }
                else if(Song.volume < 0)
                {
                    Song.volume = 0;
                    Song.Pause();
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if(nowPlaying && !isOver && !Invincible)
            {
                if(collision.collider.tag == "Wall")
                {
                    isOver = true;
                    AudioSource.PlayClipAtPoint(DieAudioN, transform.position);
                    LineRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    Instantiate(DieEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}
