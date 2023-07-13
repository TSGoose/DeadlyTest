using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private Transform playerTransform;
    public EnemyType enemyType;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = enemyType.Speed;
        affectedArea = enemyType.AffectedArea;
        shotTime = enemyType.ShotTime;
        hp = enemyType.hp;
    }


    private float hp;
    private float speed;
    public Vector2 moveVector;
    private float affectedArea = 0.5f;
    private float deltaX; 
    void Update()
    {
        Reflect();
        Run();
        Kick();
        if (reload) Reload();
        if (hp <= 0) Destroy(gameObject);
    }

    void Run()
    {
        
        if (Mathf.Abs(deltaX) > affectedArea)
        {
            moveVector.x = -1;
            if (faceRight) 
                moveVector.x = 1;
        }
        else
        {
            moveVector.x = 0;
        }
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    public bool faceRight;

    void Reflect()
    {
        deltaX = playerTransform.position.x - transform.position.x;
        if (!(deltaX > 0 && faceRight || deltaX < 0 && !faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    private float shotTime;
    public bool reload;
    RaycastHit2D inAffectedArea;
    public Transform Arm;
    public float checkRadius = 0.5f;
    public LayerMask Player;

    void Kick()
    {
        inAffectedArea = Physics2D.Raycast(Arm.position, -Arm.TransformDirection(Vector2.right), checkRadius, Player);
        //Debug.Log(Arm.up);
        if (inAffectedArea.collider != null && !reload) 
        {
            Debug.Log(hp);
            if (inAffectedArea.collider.CompareTag("Player")) {
                reload = true;
                inAffectedArea.collider.GetComponent<Player>().TakeDamage(enemyType.Damage);
            }
        }
    }

    void Reload()
    {
        if (shotTime > 0)
            shotTime -= Time.deltaTime;
        else
        {
            reload = false;
            shotTime = enemyType.ShotTime;
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

}
