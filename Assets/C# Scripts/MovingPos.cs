using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPos : MonoBehaviour
{
    public GameObject Object;
    public Vector3 StartPosition;
    public Vector3 FinishPosition;
    public float Needtime;

    void Start()
    {
        Object.transform.position = StartPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Line")
        {
            Object.transform.DOMove(FinishPosition, Needtime).SetEase(Ease.OutCubic);
        }
    }
}
