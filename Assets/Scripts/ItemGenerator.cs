using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites = new Sprite[20];   // 스프라이트 총 20개
    public GameObject itemPrefab;   // 빈 오브젝트에 콜라이더 추가돼 있음

    float span = 1.0f;  // 아이템 나오는 시간 간격
    float delta = 0;

    public int[] seasonRatio = new int[100];     // 아이템 확률 합은 총 100%
    int dropItem = 0;

    // Start is called before the first frame update
    void Start()
    {

        span = 1.0f;    // 아이템 나오는 시간 간격
        delta = 0;      // 지난 시간

        // 공통: 0, 봄: 1, 여름: 2, 가을: 3, 겨울: 4
        // 0~4: 현재 계절, 5~19: 공통, 20~39: 봄, 40~59: 여름, 60~79: 가을, 80~99: 겨울
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

            // 아이템 선택
            int dropSeason = seasonRatio[Random.Range(0, 100)];
            dropItem = Random.Range(4 * dropSeason, 4 * dropSeason + 4);
            spriteRenderer.sprite = sprites[dropItem];
            // 0: 아이스, 1: 핫, 2: 디저트, 3: 카페인, 4: 디카페인, 5: 괴식, 6: 민초
            // 공통
        
            if (dropItem == 0) dropController.features = new bool[] {false, false, false, false, true, true, false}; // 눈의 솔
            else if (dropItem == 1) dropController.features = new bool[] { false, false, false, false, true, true, false};    // 데자바
            else if (dropItem == 2) dropController.features = new bool[] { false, false, true, false, false, false, false};   // 허니브레드
            else if (dropItem == 3) dropController.features = new bool[] { false, false, true, false, false, false, false};   // 쿠키
            // 봄
            else if (dropItem == 4) dropController.features = new bool[] { false, false, true, false, false, false, false};   // 벚꽃빵
            else if (dropItem == 5) dropController.features = new bool[] { true, false, false, false, false, false, false};   // 버블티
            else if (dropItem == 6) dropController.features = new bool[] { false, true, false, true, false, false, false};    // 카푸치노
            else if (dropItem == 7) dropController.features = new bool[] { true, false, false, false, true, false, false};    // 레몬에이드
            // 여름
            else if (dropItem == 8) dropController.features = new bool[] { true, false, false, true, false, false, false};    // 아이스 아메리카노
            else if (dropItem == 9) dropController.features = new bool[] { true, false, true, false, false, false, false};    // 빙수
            else if (dropItem == 10) dropController.features = new bool[] { true, false, false, false, true, false, true};    // 민초라떼
            else if (dropItem == 11) dropController.features = new bool[] { true, false, false, true, false, false, false};   // 아이스 바닐라라떼
            // 가을
            else if (dropItem == 12) dropController.features = new bool[] { false, true, false, false, true, false, false};   // 캐모마일 티
            else if (dropItem == 13) dropController.features = new bool[] { true, false, true, true, false, false, false};    // 아포카토
            else if (dropItem == 14) dropController.features = new bool[] { false, false, false, true, false, false, false};  // 홍차
            else if (dropItem == 15) dropController.features = new bool[] { false, false, true, false, false, false, false};  // 샌드위치
            // 겨울
            else if (dropItem == 16) dropController.features = new bool[] { false, true, false, true, false, false, false};   // 카페라떼
            else if (dropItem == 17) dropController.features = new bool[] { false, true, false, true, false, false, false};   // 비엔나 커피
            else if (dropItem == 18) dropController.features = new bool[] { false, true, true, false, false, false, false};   // 딸기 케이크
            else if (dropItem == 19) dropController.features = new bool[] { false, true, true, false, false, false, false};   // 붕어빵

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
            Debug.Log("계절: " + dropSeason);
            Debug.Log("아이템: " + dropItem);
            Debug.Log("");

            int dropX = Random.Range(-6, 7);
            drop.transform.position = new Vector3(dropX, 7, 0);
        }
    }

  
}
