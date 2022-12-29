using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    public int Check;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SceneChange()
    {
        if (Check == 0)
            SceneManager.LoadScene("Explain");
        else if (Check == 1)
            SceneManager.LoadScene("Main");
    }
}
