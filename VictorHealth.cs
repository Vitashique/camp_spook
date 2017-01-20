using UnityEngine;
using System.Collections;

public class VictorHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public GameObject gameOver;
    private bool flash;
    private bool b_takeDamage;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer victor;

	void Start ()
    {
        currentHealth = maxHealth;
        victor = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {
        //when player's health reaches 0, he gets disabled/disappears
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            gameOver.SetActive(true);
        }


        if(flash)
        {
            if(flashCounter > flashLength * 0.66f)
            {
                victor.color = new Color(victor.color.r, victor.color.g, victor.color.b, 0f);
            }

            else if(flashCounter > flashLength * 0.33f)
            {
                victor.color = new Color(victor.color.r, victor.color.g, victor.color.b, 1f);
            }

            else if(flashCounter > 0f)
            {
                victor.color = new Color(victor.color.r, victor.color.g, victor.color.b, 0f);
            }

            else
            {
                victor.color = new Color(victor.color.r, victor.color.g, victor.color.b, 1f);
                flash = false;
            }

            flashCounter -= Time.deltaTime;
        }
        if(b_takeDamage)
        {
            victorTakesDamage(1);
        }
    }

    public void victorTakesDamage(int damageTaken)
    {
        currentHealth -= damageTaken;

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        flash = true;
        flashCounter = flashLength;
    }

    public void continueToTakeDamage (bool b_yN)
    {
        b_takeDamage = b_yN;
    }


    public void giveHealth(int healthAddition)
    {
       //make sure we don't go over health limit
       if(currentHealth + healthAddition > maxHealth)
       {
            currentHealth = maxHealth;
       }
       else
       {
            currentHealth += healthAddition;
       }
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
