using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Line;

public class CameraBindChange : MonoBehaviour
{
    public Vector3 ToPosition;
    public Vector3 ToRotation;
    public float ToExtent;
    public float Needtime = 1;
    private MainLine Line;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Line.MainLine>())
        {
            Line = other.GetComponent<Line.MainLine>();
            Line.CameraBindPosition = ToPosition;    //平滑更改 Position 不受 Needtime 控制，而受 MainLine 中的 FollowingNeedtime 控制
            Line.CameraBind.transform.DORotate(ToRotation, Needtime).SetEase(Ease.InOutSine);
            Line.CameraBind.transform.DOScale(new Vector3(ToExtent, ToExtent, ToExtent), Needtime).SetEase(Ease.InOutSine);
        }
    }
}
