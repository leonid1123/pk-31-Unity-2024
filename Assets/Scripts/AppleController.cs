using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppleController : MonoBehaviour
{

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerController>().SetApples(1);
            int apples = collision.GetComponent<PlayerController>().GetApples();
            GameObject.Find("AppleText").GetComponent<TextMeshProUGUI>().SetText($"Яблок:{apples}");
            Destroy(this.gameObject);
        }
    }
}
