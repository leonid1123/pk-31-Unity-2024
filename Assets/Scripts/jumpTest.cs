using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTest : MonoBehaviour
{
    [SerializeField]
    float vx;
    [SerializeField]
    float vy;
    Rigidbody2D rb2d;
    float mov;
    [SerializeField]
    float spd;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            rb2d.AddForce(new Vector2(1*vx,1*vy),ForceMode2D.Impulse);
        }
        mov = Input.GetAxis("Horizontal");
        rb2d.AddForce(new Vector3(mov*spd*Time.deltaTime,rb2d.velocityY,0));
    }
}
