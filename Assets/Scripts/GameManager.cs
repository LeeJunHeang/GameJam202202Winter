using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int age; // �÷��̾� ����
    int player; //�÷��̾� Ư��. 
    //0: ���ľ�ȣ�� 1: ���׾� 2: ����Ʈ��ȣ�� 3: ī�����ߵ��� 4: ī���ξ˷���

    public Season season; //���� Ư���� �޾ƿ��� ���� Ŭ����

    // Start is called before the first frame update
    void Start()
    {
        age = 10; // ó�� ���̴� 1020.
        player =  Random.Range(0,5); //0~4���� Ư�� ���� �ο�
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void calculate() //���� Ư���� ���� ���� ����ϴ� �Լ�
    {

    }
}
