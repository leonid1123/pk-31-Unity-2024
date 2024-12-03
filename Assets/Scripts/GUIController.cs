using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Image playerHP;
    public Sprite[] hearts = new Sprite[4];
    //для спавнилки банана
    public GameObject banana;
    public Transform bananaSpawner;

    
    public void SetSprite(int _sprite) 
    {
        playerHP.sprite = hearts[_sprite];
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) {
            Instantiate(banana, bananaSpawner.position, transform.rotation );
        }
    }
}
