using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public Vector3 TurnAround1 = new Vector3(0, 90, 0), TurnAround2 = new Vector3(0, 0, 0);
    public bool TurnToTA1 = true;

    public GameObject LineTail;
    private GameObject nowTail;

    private bool nowPlaying = false;


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
        Song.Pause();

        if(TurnToTA1)
        {
            transform.localEulerAngles = TurnAround1;
        }
        else
        {
            transform.localEulerAngles = TurnAround2;
        }

        nowTail = Instantiate(LineTail, transform.position, transform.rotation);
        nowPlaying = false;

        CameraBind.transform.eulerAngles = CameraBindEulerAngles;
        CameraBind.transform.localScale = new Vector3(CameraFollowingExtent, CameraFollowingExtent, CameraFollowingExtent);
    }

    //Update函数每帧调用一次
    void Update()
    {
        if(nowPlaying)
        {
            transform.Translate(0, 0, Time.deltaTime * Speed);

            if(IsGrounded())
            {
                if(nowTail == null)
                {
                    nowTail = Instantiate(LineTail, transform.position, transform.rotation);
                }
                nowTail.transform.Translate(0, 0, (Time.deltaTime / 2 * Speed));
                nowTail.transform.localScale += new Vector3(0, 0, (Time.deltaTime * Speed));

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
            Song.Play();
        }
    }
}
