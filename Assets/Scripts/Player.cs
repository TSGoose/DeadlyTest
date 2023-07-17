using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeadlyTest.Architecture
{

    public class Player : MonoBehaviour
    {

        private PlayerRepository playerRepository;
        public PlayerInteractor playerInteractor;

        public Rigidbody2D rb;
        public Animator anim;

        public Gun gun;
        // Start is called before the first frame update
        void Start()
        {
            this.playerRepository = new PlayerRepository();
            this.playerRepository.Initialize();

            this.playerInteractor = new PlayerInteractor(this.playerRepository);
            this.playerInteractor.Initialize();
            this.playerInteractor.ClearScore();

            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            checkRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
            speed = BaseSpeed;
            hp = max_hp;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) ExitToMenu();
            Run();
            Jump();
            CheckingGround();
            Reflect();
            Shift();
            if (hp <= 0) OpenDeadScreen();
            //transform.Translate(transform.right * speed * Time.deltaTime);

        }

        public float BaseSpeed;
        private float speed;
        public Vector2 moveVector;
        public int max_hp = 10;
        public int hp = 10;

        void OpenDeadScreen()
        {
            Scenes.OpenDeadScreen();
        }

        void ExitToMenu()
        {
            Scenes.OpenMenu();
        }

        void Run()
        {
            moveVector.x = Input.GetAxisRaw("Horizontal");
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

        public Collider2D poseStand;
        public Collider2D poseShift;

        void Shift()
        {
            if (onGround && Input.GetKey(KeyCode.LeftShift))
            {
                speed = BaseSpeed / 2;
                poseStand.enabled = false;
                poseShift.enabled = true;
                anim.SetBool("onShift", true);
            }
            else
            {
                speed = BaseSpeed;
                poseStand.enabled = true;
                poseShift.enabled = false;
                anim.SetBool("onShift", false);
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
}