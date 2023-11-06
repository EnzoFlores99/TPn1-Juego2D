using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerHeart : MonoBehaviour
{
    public static ControllerHeart instance;
    public Image Heart1, Heart2, Heart3;
    public Sprite heartFull, heartEmpty;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void UpdateHealthDisplay()
    {
        switch(HealthCharacter.instance.currentHealth)
        {
            case 3:
            Heart1.sprite=heartFull;
            Heart2.sprite=heartFull;
            Heart3.sprite=heartFull;
            break;

            case 2:
            Heart1.sprite=heartFull;
            Heart2.sprite=heartFull;
            Heart3.sprite=heartEmpty;
            
            break;

            case 1:
            Heart1.sprite=heartFull;
            Heart2.sprite=heartEmpty;
            Heart3.sprite=heartEmpty;
            break;

            case 0:
            Heart1.sprite=heartEmpty;
            Heart2.sprite=heartEmpty;
            Heart3.sprite=heartEmpty;
            break;

        }
    }
}
