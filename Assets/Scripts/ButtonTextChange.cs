using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextChange : MonoBehaviour
{
    public Text t;

    public Change change;

    void Start()
    {
        
    }


    void Update()
    {
        if(change.Index == 4)
        {
            t.GetComponent<Text>().text = "게임 시작";
        }
    }
}
