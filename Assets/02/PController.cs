using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float rbMov = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(rbMov*3,0,0);
        anim.SetFloat("mov",rbMov*rbMov);

    }
}
