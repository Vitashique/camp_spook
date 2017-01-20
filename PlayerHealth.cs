using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    private bool flash;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer victor;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
        victor = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //when player's health reaches 0, he gets disabled/disappears
	    if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
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
	}

    public void HurtPlayer(int damageTaken)
    {
        currentHealth -= damageTaken;
        flash = true;
        flashCounter = flashLength;
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
