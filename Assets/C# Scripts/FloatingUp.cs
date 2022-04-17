using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingUp : MonoBehaviour
{
    public GameObject Object;
    public float StartY = -3.01f;
    public float FinishY;
    public float Needtime;

    void Start()
    {
        Object.transform.position = new Vector3(Object.transform.position.x, StartY, Object.transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Line")
        {
            Object.transform.DOMoveY(FinishY, Needtime).SetEase(Ease.OutCirc);
        }
    }
}
