using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private float mov;
    [SerializeField]
    private float speed;//10, gravity = 3
    [SerializeField]
    private float jumpForce;//16
    [SerializeField]
    private float test;
    private bool facingRight = true;
    private int apples = 0;
    private bool onGround = false;
    private int HP = 3;
    public GUIController gui;

    public void SetApples(int applesToAdd)
    {
        apples += applesToAdd;
    }

    public int GetApples()
    {
        return apples;
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Обработка столкновений, если необходимо
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Логика столкновения с врагом
            Debug.Log("игрок столкнулся с врагом!");
            HP-=1;
            gui.SetSprite(HP);
            if (HP<=0) {
                SceneManager.LoadScene(0);
            }           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = true;
            anim.SetBool("onLand", true);
        }
        if (collision.CompareTag("Enemy"))
        {
            Vector3 player = transform.position;
            Vector3 snail = collision.transform.position;
            Vector3 pinok = player - snail;
            rb2d.AddForce(pinok.normalized * test, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = false;
            anim.SetBool("onLand", false);
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimationParameters();
    }

    private void HandleMovement()
    {
        mov = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(mov * speed, rb2d.velocity.y);

        if (mov > 0 && !facingRight)
        {
            Flip();
        }
        else if (mov < 0 && facingRight)
        {
            Flip();
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.J) && onGround)
        {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }

    private void UpdateAnimationParameters()
    {
        anim.SetFloat("vspeed", rb2d.velocity.y);
        anim.SetFloat("movement", Mathf.Abs(mov));
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
