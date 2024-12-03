using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour
{
    Collider2D coll;
    void Start()
    {
        Rigidbody2D banana = gameObject.GetComponent<Rigidbody2D>();
        banana.AddForce(Vector2.up*5,ForceMode2D.Impulse);
        coll = gameObject.GetComponent<Collider2D>();
        coll.enabled = false;
        StartCoroutine(ColliderOn());
    }
    IEnumerator ColliderOn() {
        yield return new WaitForSeconds(1);
        coll.enabled = true;
    }
}
