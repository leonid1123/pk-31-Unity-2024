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
    void Update()
    {
        mov = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector3(mov*spd*Time.deltaTime,rb2d.velocityY,0);
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
