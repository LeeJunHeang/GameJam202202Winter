using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[20];   // ��������Ʈ �� 20��
    public GameObject itemPrefab;   // �� ������Ʈ�� �ݶ��̴� �߰��� ����

    float span = 1.0f;  // ������ ������ �ð� ����
    float delta = 0;

    public int[] seasonRatio = new int[100];     // ������ Ȯ�� ���� �� 100%
    int dropItem = 0;

    // Start is called before the first frame update
    void Start()
    {

        span = 1.0f;    // ������ ������ �ð� ����
        delta = 0;      // ���� �ð�

        // ����: 0, ��: 1, ����: 2, ����: 3, �ܿ�: 4
        // 0~4: ���� ����, 5~19: ����, 20~39: ��, 40~59: ����, 60~79: ����, 80~99: �ܿ�
        for (int i = 0; i < 5; i++)
            seasonRatio[i] = 0;
        for (int i = 5; i < 20; i++)
            seasonRatio[i] = 0;
        for (int i = 20; i < 40; i++)
            seasonRatio[i] = 1;
        for (int i = 40; i < 60; i++)
            seasonRatio[i] = 2;
        for (int i = 60; i < 80; i++)
            seasonRatio[i] = 3;
        for (int i = 80; i < 100; i++)
            seasonRatio[i] = 4;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject drop = Instantiate(itemPrefab);
            ItemController dropController = drop.GetComponent<ItemController>();
            spriteRenderer = drop.GetComponent<SpriteRenderer>();

            // ������ ����
            int dropSeason = seasonRatio[Random.Range(0, 100)];
            dropItem = Random.Range(4 * dropSeason, 4 * dropSeason + 4);
            spriteRenderer.sprite = sprites[dropItem];
            // 0: ���̽�, 1: ��, 2: ����Ʈ, 3: ī����, 4: ��ī����, 5: ����, 6: ����
            // ����
        
            if (dropItem == 0) dropController.features = new bool[] {false, false, false, false, true, true, false}; // ���� ��
            else if (dropItem == 1) dropController.features = new bool[] { false, false, false, false, true, true, false};    // ���ڹ�
            else if (dropItem == 2) dropController.features = new bool[] { false, false, true, false, false, false, false};   // ��Ϻ극��
            else if (dropItem == 3) dropController.features = new bool[] { false, false, true, false, false, false, false};   // ��Ű
            // ��
            else if (dropItem == 4) dropController.features = new bool[] { false, false, true, false, false, false, false};   // ���ɻ�
            else if (dropItem == 5) dropController.features = new bool[] { true, false, false, false, false, false, false};   // ����Ƽ
            else if (dropItem == 6) dropController.features = new bool[] { false, true, false, true, false, false, false};    // īǪġ��
            else if (dropItem == 7) dropController.features = new bool[] { true, false, false, false, true, false, false};    // �����̵�
            // ����
            else if (dropItem == 8) dropController.features = new bool[] { true, false, false, true, false, false, false};    // ���̽� �Ƹ޸�ī��
            else if (dropItem == 9) dropController.features = new bool[] { true, false, true, false, false, false, false};    // ����
            else if (dropItem == 10) dropController.features = new bool[] { true, false, false, false, true, false, true};    // ���ʶ�
            else if (dropItem == 11) dropController.features = new bool[] { true, false, false, true, false, false, false};   // ���̽� �ٴҶ��
            // ����
            else if (dropItem == 12) dropController.features = new bool[] { false, true, false, false, true, false, false};   // ĳ���� Ƽ
            else if (dropItem == 13) dropController.features = new bool[] { true, false, true, true, false, false, false};    // ����ī��
            else if (dropItem == 14) dropController.features = new bool[] { false, false, false, true, false, false, false};  // ȫ��
            else if (dropItem == 15) dropController.features = new bool[] { false, false, true, false, false, false, false};  // ������ġ
            // �ܿ�
            else if (dropItem == 16) dropController.features = new bool[] { false, true, false, true, false, false, false};   // ī���
            else if (dropItem == 17) dropController.features = new bool[] { false, true, false, true, false, false, false};   // �񿣳� Ŀ��
            else if (dropItem == 18) dropController.features = new bool[] { false, true, true, false, false, false, false};   // ���� ����ũ
            else if (dropItem == 19) dropController.features = new bool[] { false, true, true, false, false, false, false};   // �ؾ

            switch (dropItem)
            {
                case 0: case 1: case 2: case 3:
                    dropController.seasonNum = 0;
                    break;
                case 4: case 5: case 6: case 7:
                    dropController.seasonNum = 1;
                    break;
                case 8: case 9: case 10: case 11:
                    dropController.seasonNum = 2;
                    break;
                case 12: case 13: case 14: case 15:
                    dropController.seasonNum = 3;
                    break;
                case 16: case 17: case 18: case 19:
                    dropController.seasonNum = 4;
                    break;
            }

            Debug.Log("");
            Debug.Log("����: " + dropSeason);
            Debug.Log("������: " + dropItem);
            Debug.Log("");

            int dropX = Random.Range(-6, 7);
            drop.transform.position = new Vector3(dropX, 7, 0);
        }
    }

  
}
