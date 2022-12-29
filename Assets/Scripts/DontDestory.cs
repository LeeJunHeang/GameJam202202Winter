using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{

    public Season season;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(season.endCount == 4)
        {
            GameObject.Find("Canvas").transform.Find("EndScore").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Score").gameObject.SetActive(false);
        }
    }

}
