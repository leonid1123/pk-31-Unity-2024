using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Image playerHP;
    public Sprite[] hearts = new Sprite[4];
    
    public void SetSprite(int _sprite) 
    {
        playerHP.sprite = hearts[_sprite];
    }
}
