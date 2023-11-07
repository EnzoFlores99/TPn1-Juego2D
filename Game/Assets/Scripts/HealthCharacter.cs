using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCharacter : MonoBehaviour
{
    public static HealthCharacter instance;
    public int currentHealth, maxHealth;
    public float invincibleLenght;
    private float invincibleCounter;
    private SpriteRenderer theSr;
    private void Awake()
    {
        instance = this;
    }
   
    void Start()
    {
        currentHealth = maxHealth;
        theSr= GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(invincibleCounter>0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter<= 0)
            {
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b,1f);
            }
        }
    }

    public void DealDamage()
    {
        if(invincibleCounter<=0)
        {
            currentHealth--;
        if (currentHealth<=0)
        {
            currentHealth=0;
            gameObject.SetActive(false);
            GameOver();
            

        }
        else
        {
            invincibleCounter = invincibleLenght;
            theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b,0.5f);
        }

        ControllerHeart.instance.UpdateHealthDisplay();
        }
        
    }
    public void GameOver()
    {
           SceneManager.LoadScene(3);
    }
}
