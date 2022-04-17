using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taper : MonoBehaviour
{
    public bool AutoTap = false;
    public bool ShowFeedback = true;
    public GameObject Effect;
    private bool Done = false;

    void Start()
    {
        if(AutoTap)
        {
            GetComponent<BoxCollider>().size = new Vector3(0.001f, 1.5f, 0.001f);
            GetComponent<BoxCollider>().center = new Vector3(0f, 0.75f, 0.5f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Line.MainLine>())
        {
            if(!AutoTap)
            {
                if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    if(ShowFeedback){ Instantiate(Effect, transform.position, transform.rotation); }
                    Destroy(gameObject);
                }
            }
            else
            {
                if(!Done)
                {
                    if(ShowFeedback){ Instantiate(Effect, transform.position, transform.rotation); }
                    other.GetComponent<Line.MainLine>().TurnBlock();
                    Done = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
