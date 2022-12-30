using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    AudioSource audioSource;

    public int Check;
    public int Index = 0;
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void SceneChange()
    {
        audioSource.Play();
        if (Check == 0)
        {
            SceneManager.LoadScene("Explain");
        }
        else if (Check == 1)
        {
            if(Index == 1)
            {
                GameObject.Find("BackGrounds").transform.Find("메뉴설명1").gameObject.SetActive(false);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명2").gameObject.SetActive(true);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명3").gameObject.SetActive(false);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명4").gameObject.SetActive(false);
            }
            else if(Index == 2)
            {
                GameObject.Find("BackGrounds").transform.Find("메뉴설명1").gameObject.SetActive(false);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명2").gameObject.SetActive(false);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명3").gameObject.SetActive(true);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명4").gameObject.SetActive(false);
            }
            else if(Index == 3)
            {
                GameObject.Find("BackGrounds").transform.Find("메뉴설명1").gameObject.SetActive(false);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명2").gameObject.SetActive(false);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명3").gameObject.SetActive(false);
                GameObject.Find("BackGrounds").transform.Find("메뉴설명4").gameObject.SetActive(true);
            }
            else if(Index == 4)
            {
                SceneManager.LoadScene("Main");
                Check++;
            }
            Index++;
        }
            

            
    }
}
