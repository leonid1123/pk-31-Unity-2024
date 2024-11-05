using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    float mov;
    [SerializeField]
    float spd;
    bool toRight = true;
    int apples = 0;
    bool onGround = false;
    public void SetApples(int _applesToAdd)
    {
        apples += _applesToAdd;
    }
    public int GetApples()
    {
        return apples;
    }
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            onGround = true;
            anim.SetBool("onLand",true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            onGround = false;
            anim.SetBool("onLand",false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) & onGround) 
        {
            rb2d.AddForce(Vector2.up*12 + rb2d.velocity*0.8f,ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }

        anim.SetFloat("vspeed", rb2d.velocityY);

        mov = Input.GetAxis("Horizontal");
        //rb2d.velocity = new Vector3(mov*spd*Time.deltaTime,rb2d.velocityY,0);
        rb2d.AddForce(new Vector3(mov*spd*Time.deltaTime,rb2d.velocityY,0));
        anim.SetFloat("movement",Mathf.Abs(mov));

        if (rb2d.velocityX>0 & !toRight)
        {
            gameObject.transform.Rotate(0, 180, 0);
            toRight = true;
        } else if(rb2d.velocityX < 0 & toRight)
        {
            gameObject.transform.Rotate(0, 180, 0);
            toRight = false;
        }
    }
}
