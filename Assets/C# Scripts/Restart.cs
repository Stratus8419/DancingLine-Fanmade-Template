using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public KeyCode RestartKeyCode;

    void Update()
    {
        if(Input.GetKeyDown(RestartKeyCode))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
