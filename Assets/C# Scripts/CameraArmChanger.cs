using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Line;

public class CameraArmChanger : MonoBehaviour
{
    public Vector3 ToPosition;
    public Vector3 ToRotation;
    public float ToExtent;
    public float ToNeedtime;
    [Space(16)]
    public float Needtime = 1;
    public Ease EasingFunction = Ease.InOutSine;
    private MainLine Line;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Line.MainLine>())
        {
            Line = other.GetComponent<Line.MainLine>();
            DOTween.To(() => Line.CameraArmPosition, x => Line.CameraArmPosition = x, ToPosition, Needtime).SetEase(EasingFunction);
            Line.CameraArm.transform.DORotate(ToRotation, Needtime).SetEase(EasingFunction);
            Line.CameraArm.transform.DOScale(new Vector3(ToExtent, ToExtent, ToExtent), Needtime).SetEase(EasingFunction);
            DOTween.To(() => Line.FollowingNeedtime, x => Line.FollowingNeedtime = x, ToNeedtime, Needtime).SetEase(EasingFunction);
        }
    }
}
