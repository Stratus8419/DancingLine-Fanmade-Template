using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLTBTrigger : MonoBehaviour
{
    [Header("此脚本已过时\n建议使用 TaperAutoCreater 脚本")]
    public GameObject LineTBTrigger;
    public float LineSpeed = 15;
    public float BPM;
    public float[] Beats;
    private bool T1 = true;

    void TurnBlockLTBT(float TA1, float TA2)
    {
        if(T1)
        {
            T1 = false;
            transform.localEulerAngles = new Vector3(0, TA2, 0);
        }
        else
        {
            T1 = true;
            transform.localEulerAngles = new Vector3(0, TA1, 0);
        }
    }

    //Start函数在第一帧调用
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 90, 0);
        for(int i = 0; i < Beats.Length; i++)
        {
            transform.Translate(0, 0, Beats[i] / (BPM / 60) / 4 * LineSpeed);
            Instantiate(LineTBTrigger, transform.position, transform.rotation);
            TurnBlockLTBT(90, 0);
        }
    }
}
