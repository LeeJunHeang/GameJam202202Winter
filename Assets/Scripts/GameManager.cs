using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int age; // 플레이어 나이
    int player; //플레이어 특성. 
    //0: 괴식애호가 1: 얼죽아 2: 디저트애호가 3: 카페인중독자 4: 카페인알러지

    public Season season; //계절 특성을 받아오기 위한 클래스

    // Start is called before the first frame update
    void Start()
    {
        age = 10; // 처음 나이는 1020.
        player =  Random.Range(0,5); //0~4까지 특성 랜덤 부여
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void calculate() //음식 특성에 따라 점수 계산하는 함수
    {

    }
}
