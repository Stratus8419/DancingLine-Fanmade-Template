using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaperEffect : MonoBehaviour
{
    public float BSpeed = 12f;

    float Uniform()
    {
        return BSpeed * Time.deltaTime;
    }

    //Update函数每帧调用一次
    void Update()
    {
        transform.localScale += new Vector3(Uniform(), Uniform(), Uniform());
        GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 2f * Time.deltaTime);
    }
}
