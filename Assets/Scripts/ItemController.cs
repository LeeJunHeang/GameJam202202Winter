using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject player;
    Vector2 dir;
    int speed = 2;  // ���� ����. ���� �ӵ�. ���ӸŴ������� ���� �޾ƿͼ� �ڵ忡 �ٷ� �ֱ�.

    public bool[] features = new bool[7];

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // �����Ӹ��� ��� ����. ���� �������� ������ ������.
        transform.Translate(0, -0.1f * speed, 0);

        // ȭ�� ������ ������ ������Ʈ ����
        if (transform.position.y < -3.5)
            Destroy(gameObject);

        // �浹 ����
        dir = transform.position - this.player.transform.position;  // �����۰� �÷��̾� �Ÿ�
        if (dir.magnitude < 0.16f + 0.95f)  // �����۰� �÷��̾� �ݰ�
            Destroy(gameObject);
    }
}
