using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int playerSpeed = 10;
    Rigidbody2D rid2D;
    void Start()
    {
        rid2D = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rid2D.velocity = new Vector2(rid2D.velocity.normalized.x * 0, rid2D.velocity.y);
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rid2D.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rid2D.velocity = new Vector2( (-1) * playerSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rid2D.velocity = new Vector2(playerSpeed, 0);
        }
    }
}
