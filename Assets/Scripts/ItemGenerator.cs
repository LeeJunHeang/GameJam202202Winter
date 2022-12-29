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
            int dropItem = Random.Range(1 * dropSeason, 4 * dropSeason);
            spriteRenderer.sprite = sprites[dropItem];
            Debug.Log("");
            Debug.Log("����: " + dropSeason);
            Debug.Log("������: " + dropItem);
            Debug.Log("");

            int dropX = Random.Range(-6, 7);
            drop.transform.position = new Vector3(dropX, 7, 0);
        }
    }
}
