using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Season : MonoBehaviour
{
    int season = 0;
    int endCount = 0;

    float timer;
    float springTime;
    float summerTime;
    float fallTime;
    float winterTime;
    float endYear;
    void Start()
    {
        timer = 0.0f;
        springTime = 0.0f;
        summerTime = 10.0f;
        fallTime = 30.0f;
        winterTime = 40.0f;
        endYear = 60.0f;
        GameObject.Find("BackGround").transform.Find("Spring").gameObject.SetActive(true);
        GameObject.Find("BackGround").transform.Find("Summer").gameObject.SetActive(false);
        GameObject.Find("BackGround").transform.Find("Fall").gameObject.SetActive(false);
        GameObject.Find("BackGround").transform.Find("Winter").gameObject.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > springTime && season == 0)
        {
            season = 1;
            GameObject.Find("BackGround").transform.Find("Spring").gameObject.SetActive(true);
            GameObject.Find("BackGround").transform.Find("Summer").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Fall").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Winter").gameObject.SetActive(false);
            Debug.Log("Spring");
        }
        else if(timer > summerTime && season == 1)
        {
            season = 2;
            GameObject.Find("BackGround").transform.Find("Spring").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Summer").gameObject.SetActive(true);
            GameObject.Find("BackGround").transform.Find("Fall").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Winter").gameObject.SetActive(false);
            Debug.Log("Summer");
        }
        else if(timer > fallTime && season == 2)
        {
            season = 3;
            GameObject.Find("BackGround").transform.Find("Spring").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Summer").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Fall").gameObject.SetActive(true);
            GameObject.Find("BackGround").transform.Find("Winter").gameObject.SetActive(false);
            Debug.Log("Fall");
        }
        else if(timer > winterTime && season == 3) 
        {
            season = 4;
            GameObject.Find("BackGround").transform.Find("Spring").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Summer").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Fall").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Winter").gameObject.SetActive(true);
            Debug.Log("Winter");
        }
        else if(timer >= endYear && season == 4)
        {
            timer = 0.0f;
            season = 0;
            endCount++;
        }
        
    }
}
