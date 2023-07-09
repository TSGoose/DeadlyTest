using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        checkRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;

    }
    
    // Update is called once per frame
    void Update()
    {
        
        Walk();
        Jump();
        CheckingGround();
        Reflect();
        //transform.Translate(transform.right * speed * Time.deltaTime);

    }  

    public float speed;
    public Vector2 moveVector;

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
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
    public float checkRadius = 0.15f;
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
    }


}
