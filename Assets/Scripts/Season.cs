using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Season : MonoBehaviour
{
    public GameManager GM;

    AudioSource audioSource;
    public AudioClip[] bgMusic = new AudioClip[4];

    int season = 0; //계절 표시 
    public int endCount = 0;

    float timer;
    float springTime;
    float summerTime;
    float fallTime;
    float winterTime;
    float endYear;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        timer = 0.0f;
        springTime = 0.0f; //0~10 봄
        summerTime = 1.0f; //10~30 여름
        fallTime = 3.0f; //30~40 가을
        winterTime = 4.0f; //40~60 겨울
        endYear = 6.0f; //0으로 초기화. 
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
            for (int i = 0; i < 5; i++)
                GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>().seasonRatio[i] = season;
            audioSource.clip = bgMusic[season - 1];
            audioSource.Play();
        }
        else if(timer > summerTime && season == 1)
        {
            season = 2;
            GameObject.Find("BackGround").transform.Find("Spring").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Summer").gameObject.SetActive(true);
            GameObject.Find("BackGround").transform.Find("Fall").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Winter").gameObject.SetActive(false);
            Debug.Log("Summer");
            for (int i = 0; i < 5; i++)
                GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>().seasonRatio[i] = season;
            audioSource.clip = bgMusic[season - 1];
            audioSource.Play();
        }
        else if(timer > fallTime && season == 2)
        {
            season = 3;
            GameObject.Find("BackGround").transform.Find("Spring").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Summer").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Fall").gameObject.SetActive(true);
            GameObject.Find("BackGround").transform.Find("Winter").gameObject.SetActive(false);
            Debug.Log("Fall");
            for (int i = 0; i < 5; i++)
                GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>().seasonRatio[i] = season;
            audioSource.clip = bgMusic[season - 1];
            audioSource.Play();
        }
        else if(timer > winterTime && season == 3) 
        {
            season = 4;
            GameObject.Find("BackGround").transform.Find("Spring").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Summer").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Fall").gameObject.SetActive(false);
            GameObject.Find("BackGround").transform.Find("Winter").gameObject.SetActive(true);
            Debug.Log("Winter");
            for (int i = 0; i < 5; i++)
                GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>().seasonRatio[i] = season;
            audioSource.clip = bgMusic[season - 1];
            audioSource.Play();
        }
        else if(timer >= endYear && season == 4)
        {
            timer = 0.0f;
            season = 0;
            for (int i = 0; i < 5; i++)
                GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>().seasonRatio[i] = season;
            endCount++;
            if(endCount == 4)
            {
                Debug.Log("END");
                SceneManager.LoadScene("End");
            }
        }
        
        
    }

    public int getSeasonNum() //계절 반환해주는 함수
    {
        return season;
    }
}
