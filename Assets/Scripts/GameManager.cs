using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    int age; // �÷��̾� ����
    int player; //�÷��̾� Ư�� 0: ���ľ�ȣ�� 1: ���׾� 2: ���׶� 3: ����Ʈ ��ȣ�� 4: ī���� ��ȣ�� 5: ��ī���� ��ȣ�� 6: ���ʴ� 
    float totalScore; //����
    int seasonNum; //���� 
    int itemNum;

    public Season season; //���� Ư���� �޾ƿ��� ���� Ŭ����
    public ItemGenerator itemGenerator; //������ �ѹ��� �޾ƿ��� ���� Ŭ����
    
    public Text textScore; //���� �ؽ�Ʈ  

    // Start is called before the first frame update
    void Start()
    {
        age = 10; // ó�� ���̴� 1020.
        player =  Random.Range(0,6); //0~4���� Ư�� ���� �ο�
        if (Random.Range(0, 100) == 1)
        {
            player = 6; //1�ۼ�Ʈ�� Ȯ���� ���ʴ� ���� 
        }

        totalScore = 0;
        textScore.text = "Score : " + totalScore.ToString(); //ó���� score 0
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calculate(bool[] features, int itemSeasonNum) //���� Ư���� ���� ���� ����ϴ� �Լ�
    {
        //�÷��̾� Ư�� 0: ���ľ�ȣ�� 1: ���׾� 2: ���׶� 3: ����Ʈ ��ȣ�� 4: ī���� ��ȣ�� 5: ��ī���� ��ȣ�� 6: ���ʴ� 
        //features 0: ���̽�, 1: ��, 2: ����Ʈ, 3: ī����, 4: ��ī����, 5: ����, 6: ����
        //itemSeasonNum 0: ����, 1: ��, 2: ����, 3: ����, 4: �ܿ�
        seasonNum = season.getSeasonNum(); //���� ���� 1 : �� 2 : ���� 3 : ���� 4 : �ܿ� 

        float score = 100; //�⺻ ������ ����

        
        if (player == 0) //���� ��ȣ����
        {
            if (features[5] || features[6]) //���� ���� �� 
            {
                score *= 3; //300�� �߰�
            }
        }else if(player == 1) //���׾�
        {
            if (features[0])
            {
                score *= 3;
            }
        }else if(player == 2) //���׶�
        {
            if (features[1])
            {
                score *= 3;
            }
        }else if(player == 3) //����Ʈ ��ȣ��
        {
            if (features[2])
            {
                score *= 4;
            }
        }else if(player == 4) //ī���� ��ȣ��
        {
            if(features[3])
            {
                score *= 4;
            }
        }else if(player == 5) //��ī���� ��ȣ��
        {
            if (features[4])
            {
                score *= 6;
            }
            if (features[3])
            {
                score *= -1.5f;
            }

        }else if(player == 6) //���ʴ�
        {
            if(features[6])
            {
                score *= 7;
            }
        }

        if (seasonNum == 1) //���̰�
        {
            if(itemSeasonNum == 1) //���� ���ĵ� ���̸�
            {
                score *= 2; //200�� �߰�
            }
        }
        else if(seasonNum == 2) //�����̰�
        {
            if (features[0]) //���� ���ĵ� ���̽���
            {
                score *= 3;
            }

            if (features[1]) //���� ������ ���̸�
            {
                score *= -2; //200�� ����
            }
        }
        else if(seasonNum == 3) //�����̰�
        {
            if(itemSeasonNum==3) //���� ���ĵ� �����̸�
            {
                score *= 2; //200�� �߰�
            }
        }
        else if(seasonNum == 4) //�ܿ��̰�
        {
            if (features[1]) //���� ���ĵ� ���̸�
            {
                score *= 3; //300�� �߰�
            }

            if (features[0]) //���� ������ ���̽���
            {
                score *= -2; //200�� ����
            }
        }
        // ĳ���� Ư�� > ���� > 

        if (features[6] &&  ( player!=6 || player !=0) ) //����
        {
            score *= 0; //0��
        }
        if (features[5])
        {
            score *= -2;
        }

        totalScore += score;

        textScore.text = "Score : " + (totalScore.ToString()); //ó���� score 0
    }
}
