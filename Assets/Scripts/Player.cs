using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    
    public Rigidbody2D rb;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        checkRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ExitToMenu();
        Run();
        Jump();
        CheckingGround();
        Reflect();
        if (hp <= 0) ExitToMenu();
        //transform.Translate(transform.right * speed * Time.deltaTime);

    }  

    public float speed;
    public Vector2 moveVector;
    public int hp = 10;

    void ExitToMenu()
    {
        Scenes.OpenMenu();
    }

    void Run()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }    
    
    public float jumpForce;
    void Jump()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }
    }

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask Ground;

    public bool faceRight;

    void Reflect()
    {
        if ((moveVector.x > 0) && faceRight || (moveVector.x < 0) && !faceRight)
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }


    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
