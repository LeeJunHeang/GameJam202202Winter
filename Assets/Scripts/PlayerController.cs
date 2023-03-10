using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Season season;

    public bool mainCheck = false;
    int playerSpeed = 10;
    int year;

    Rigidbody2D rid2D;
    Animator anim;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        rid2D = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        anim = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("Explains");
            mainCheck = true;
            Time.timeScale = 0.0f;
        }
    }

    void Move()
    {
        anim.SetInteger("Year", season.endCount);
        float h = Input.GetAxisRaw("Horizontal");
        rid2D.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(3, 3, 3);
            rid2D.velocity = new Vector2( (-1) * playerSpeed, 0);
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-3, 3, 3);
            rid2D.velocity = new Vector2(playerSpeed, 0);
            anim.SetBool("Walking", true);
        }  
        if (Input.GetButtonUp("Horizontal"))
        {
            rid2D.velocity = new Vector2(rid2D.velocity.normalized.x * 0, rid2D.velocity.y);
            anim.SetBool("Walking", false);
        }
    }
}
