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
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        mov = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector3(mov*spd*Time.deltaTime,rb2d.velocityY,0);
        anim.SetFloat("movement",Mathf.Abs(mov));
    }
}