using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int age; // 플레이어 나이
    int player; //플레이어 특성 0: 괴식애호가 1: 얼죽아 2: 더죽뜨 3: 디저트 애호가 4: 카페인 애호가 5: 디카페인 애호가 6: 민초단 
    float totalScore; //점수
    int seasonNum; //계절 
    int itemNum;

    public Season season; //계절 특성을 받아오기 위한 클래스
    public ItemGenerator itemGenerator; //아이템 넘버를 받아오기 위한 클래스
    
    public Text textScore; //점수 텍스트  

    // Start is called before the first frame update
    void Start()
    {
        age = 10; // 처음 나이는 1020.
        player =  Random.Range(0,6); //0~4까지 특성 랜덤 부여
        if (Random.Range(0, 100) == 1)
        {
            player = 6; //1퍼센트의 확률로 민초단 ㅊㅊ 
        }

        totalScore = 0;
        textScore.text = "Score : " + totalScore.ToString(); //처음엔 score 0
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calculate(bool[] features, int itemSeasonNum) //음식 특성에 따라 점수 계산하는 함수
    {
        //플레이어 특성 0: 괴식애호가 1: 얼죽아 2: 더죽뜨 3: 디저트 애호가 4: 카페인 애호가 5: 디카페인 애호가 6: 민초단 
        //features 0: 아이스, 1: 핫, 2: 디저트, 3: 카페인, 4: 디카페인, 5: 괴식, 6: 민초
        //itemSeasonNum 0: 공용, 1: 봄, 2: 여름, 3: 가을, 4: 겨울
        seasonNum = season.getSeasonNum(); //현재 계절 1 : 봄 2 : 여름 3 : 가을 4 : 겨울 

        float score = 100; //기본 아이템 점수

        
        if (player == 0) //괴식 애호가면
        {
            if (features[5] || features[6]) //괴식 먹을 떄 
            {
                score *= 3; //300점 추가
            }
        }else if(player == 1) //얼죽아
        {
            if (features[0])
            {
                score *= 3;
            }
        }else if(player == 2) //더죽뜨
        {
            if (features[1])
            {
                score *= 3;
            }
        }else if(player == 3) //디저트 애호가
        {
            if (features[2])
            {
                score *= 4;
            }
        }else if(player == 4) //카페인 애호가
        {
            if(features[3])
            {
                score *= 4;
            }
        }else if(player == 5) //디카페인 애호가
        {
            if (features[4])
            {
                score *= 6;
            }
            if (features[3])
            {
                score *= -1.5f;
            }

        }else if(player == 6) //민초단
        {
            if(features[6])
            {
                score *= 7;
            }
        }

        if (seasonNum == 1) //봄이고
        {
            if(itemSeasonNum == 1) //먹은 음식도 봄이면
            {
                score *= 2; //200점 추가
            }
        }
        else if(seasonNum == 2) //여름이고
        {
            if (features[0]) //먹은 음식도 아이스면
            {
                score *= 3;
            }

            if (features[1]) //먹은 음식이 핫이면
            {
                score *= -2; //200점 감점
            }
        }
        else if(seasonNum == 3) //가을이고
        {
            if(itemSeasonNum==3) //먹은 음식도 가을이면
            {
                score *= 2; //200점 추가
            }
        }
        else if(seasonNum == 4) //겨울이고
        {
            if (features[1]) //먹은 음식도 핫이면
            {
                score *= 3; //300점 추가
            }

            if (features[0]) //먹은 음식이 아이스면
            {
                score *= -2; //200점 감점
            }
        }
        // 캐릭터 특성 > 계절 > 

        if (features[6] &&  ( player!=6 || player !=0) ) //민초
        {
            score *= 0; //0점
        }
        if (features[5])
        {
            score *= -2;
        }

        totalScore += score;

        textScore.text = "Score : " + (totalScore.ToString()); //처음엔 score 0
    }
}
