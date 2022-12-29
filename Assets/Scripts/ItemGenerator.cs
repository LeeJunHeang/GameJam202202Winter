using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[20];   // 스프라이트 총 20개
    public GameObject itemPrefab;   // 빈 오브젝트에 콜라이더 추가돼 있음

    float span = 1.0f;  // 아이템 나오는 시간 간격
    float delta = 0;
    int season = 0;  // 공통: 0, 봄: 1, 여름: 2, 가을: 3, 겨울: 4 (게임매니저에서 받아오기)


    private int[] seasonRatio = new int[100];     // 아이템 확률 합은 총 100%

    // Start is called before the first frame update
    void Start()
    {

        span = 1.0f;    // 아이템 나오는 시간 간격
        delta = 0;      // 지난 시간
        season = 0;     // 공통: 0, 봄: 1, 여름: 2, 가을: 3, 겨울: 4 (게임매니저에서 받아오기)


        // 0~4: 현재 계절, 5~19: 공통, 20~39: 봄, 40~59: 여름, 60~79: 가을, 80~99: 겨울
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

            // 아이템 선택
            int dropSeason = seasonRatio[Random.Range(0, 100)];
            int dropItem = Random.Range(1 * dropSeason, 4 * dropSeason);
            spriteRenderer.sprite = sprites[dropItem];
            Debug.Log("");
            Debug.Log("계절: " + dropSeason);
            Debug.Log("아이템: " + dropItem);
            Debug.Log("");

            int dropX = Random.Range(-6, 7);
            drop.transform.position = new Vector3(dropX, 7, 0);
        }
    }
}
