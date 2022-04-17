using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TaperAutoCreater : MonoBehaviour
{
    [Header("根据.aff文件的地面Tap自动生成路径")]
    public TextAsset AFFFile;
    public bool FirstRoadIs1 = true;
    public float LineSpeed;
    public string NotePattern = "^(?<=\\().*(?=,)";
    public GameObject Taper;

    void ChangeRoad(float TA1, float TA2)
    {
        if(FirstRoadIs1)
        {
            FirstRoadIs1 = false;
            transform.localEulerAngles = new Vector3(0, TA2, 0);
        }
        else
        {
            FirstRoadIs1 = true;
            transform.localEulerAngles = new Vector3(0, TA1, 0);
        }
    }

    // Start 函数在第一帧执行
    void Start()
    {
        LineSpeed = FindObjectOfType<Line.MainLine>().GetComponent<Line.MainLine>().Speed;

        string[] cmd = AFFFile.text.Split('\n');

        if(FirstRoadIs1)
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }

        transform.Translate(0, 0, float.Parse(cmd[0].Substring(12)) * 0.001f * LineSpeed);

        float lastTime = 0f;
        for(int i = 0; i < cmd.Length; i++)
        {
            if(Regex.IsMatch(cmd[i], NotePattern) && !(cmd[i].Contains("timing")))
            {
                float nowTime = float.Parse(Regex.Match(cmd[i], NotePattern).Value);
                transform.Translate(0, 0, (nowTime - lastTime) * LineSpeed * 0.001f);
                lastTime = nowTime;

                Instantiate(Taper, transform.position, transform.rotation);

                ChangeRoad(90, 0);
            }
        }
    }
}
