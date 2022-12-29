using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[20];   // ��������Ʈ �� 20��
    public GameObject itemPrefab;   // �� ������Ʈ�� �ݶ��̴� �߰��� ����

    float span = 1.0f;  // ������ ������ �ð� ����
    float delta = 0;
    int season = 0;  // ����: 0, ��: 1, ����: 2, ����: 3, �ܿ�: 4 (���ӸŴ������� �޾ƿ���)

    private int[] seasonRatio = new int[100];     // ������ Ȯ�� ���� �� 100%

    // Start is called before the first frame update
    void Start()
    {

        span = 1.0f;    // ������ ������ �ð� ����
        delta = 0;      // ���� �ð�
        season = 0;     // ����: 0, ��: 1, ����: 2, ����: 3, �ܿ�: 4 (���ӸŴ������� �޾ƿ���)


        // 0~4: ���� ����, 5~19: ����, 20~39: ��, 40~59: ����, 60~79: ����, 80~99: �ܿ�
        for (int i = 0; i < 5; i++)
            seasonRatio[i] = season;
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
            spriteRenderer = drop.GetComponent<SpriteRenderer>();

            // ������ ����
            int dropSeason = seasonRatio[Random.Range(0, 100)];
            int dropItem = Random.Range(4 * dropSeason, 4 * dropSeason + 4);
            spriteRenderer.sprite = sprites[dropItem];
            // ����
            if (dropItem == 0) drop.features = [false, false, false, false, true, true, false];         // ���� ��
            else if (dropItem == 1) drop.features = [false, false, false, false, true, true, false];    // ���ڹ�
            else if (dropItem == 2) drop.features = [false, false, true, false, false, false, false];   // ��Ϻ극��
            else if (dropItem == 3) drop.features = [false, false, true, false, false, false, false];   // ��Ű
            // ��
            else if (dropItem == 4) drop.features = [false, false, true, false, false, false, false];   // ���ɻ�
            else if (dropItem == 5) drop.features = [true, false, false, false, false, false, false];   // ����Ƽ
            else if (dropItem == 6) drop.features = [false, true, false, true, false, false, false];    // īǪġ��
            else if (dropItem == 7) drop.features = [true, false, false, false, true, false, false];    // �����̵�
            // ����
            else if (dropItem == 8) drop.features = [true, false, false, true, false, false, false];    // ���̽� �Ƹ޸�ī��
            else if (dropItem == 9) drop.features = [true, false, true, false, false, false, false];    // ����
            else if (dropItem == 10) drop.features = [true, false, false, false, true, false, true];    // ���ʶ�
            else if (dropItem == 11) drop.features = [true, false, false, true, false, false, false];   // ���̽� �ٴҶ��
            // ����
            else if (dropItem == 12) drop.features = [false, true, false, false, true, false, false];   // ĳ���� Ƽ
            else if (dropItem == 13) drop.features = [true, false, true, true, false, false, false];    // ����ī��
            else if (dropItem == 14) drop.features = [false, false, false, true, false, false, false];  // ȫ��
            else if (dropItem == 15) drop.features = [false, false, true, false, false, false, false];  // ������ġ
            // �ܿ�
            else if (dropItem == 16) drop.features = [false, true, false, true, false, false, false];   // ī���
            else if (dropItem == 17) drop.features = [false, true, false, true, false, false, false];   // �񿣳� Ŀ��
            else if (dropItem == 18) drop.features = [false, true, true, false, false, false, false];   // ���� ����ũ
            else if (dropItem == 19) drop.features = [false, true, true, false, false, false, false];   // �ؾ
            Debug.Log("");
            Debug.Log("����: " + dropSeason);
            Debug.Log("������: " + dropItem);
            Debug.Log("");

            int dropX = Random.Range(-6, 7);
            drop.transform.position = new Vector3(dropX, 7, 0);
        }
    }
}
