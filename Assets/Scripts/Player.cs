using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Vector2 moveVector;
    
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



    }
    
    // Update is called once per frame
    void Update()
    {
        
        Walk();
        Jump();
        CheckingGround();
        //transform.Translate(transform.right * speed * Time.deltaTime);

    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce((transform.up * jumpForce), ForceMode2D.Impulse);
            
        }
    }

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.15f;
    public LayerMask Ground;

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }


}
