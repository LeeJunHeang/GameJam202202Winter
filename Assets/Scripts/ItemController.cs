using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject player;
    Vector2 dir;
    int speed = 2;  // 삭제 예정. 낙하 속도. 게임매니저에서 나이 받아와서 코드에 바로 넣기.
    
    public GameManager gameManager; 
    

    // 0: 아이스, 1: 핫, 2: 디저트, 3: 카페인, 4: 디카페인, 5: 괴식, 6: 민초
    public bool[] features;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임마다 등속 낙하. 나이 먹을수록 빠르게 내려감.
        transform.Translate(0, -0.1f * speed, 0);
        
        // 화면 밖으로 나오면 오브젝트 삭제
        if (transform.position.y < -3.5)
            Destroy(gameObject);

        // 충돌 판정
        dir = transform.position - this.player.transform.position;  // 아이템과 플레이어 거리
        if (dir.magnitude < 0.16f + 0.95f)  // 아이템과 플레이어 반경
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll){ //플레이어와 충돌하면
      if(coll.gameObject == this.player)
        gameManager.calculate(); //점수 계산 
        Debug.Log("야옹");

    }
}
