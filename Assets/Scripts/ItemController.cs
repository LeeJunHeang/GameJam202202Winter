using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject player;
    int speed = 2;  // ���� ����. ���� �ӵ�. ���ӸŴ������� ���� �޾ƿͼ� �ڵ忡 �ٷ� �ֱ�.
    
    public GameManager gameManager;
    AudioSource audioSource;

    // 0: ���̽�, 1: ��, 2: ����Ʈ, 3: ī����, 4: ��ī����, 5: ����, 6: ����
    public bool[] features;
    public int seasonNum;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �����Ӹ��� ��� ����. ���� �������� ������ ������.
        transform.Translate(0, -0.1f * speed, 0);
        
        // ȭ�� ������ ������ ������Ʈ ����
        if (transform.position.y < -3.5)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll){ //�÷��̾�� �浹�ϸ�
        if (coll.gameObject == this.player)
        {
            audioSource.Play();
            Invoke("gameObjectDestroy", 0.5f);
            gameManager.calculate(features, seasonNum); //���� ��� 
            Debug.Log("�߿�");
        }
    }

    void gameObjectDestroy()
    {
        Destroy(gameObject);
    }
}
