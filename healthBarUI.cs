using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthBarUI : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public VictorHealth victorHealth;
    private static bool UIExists;

    void Start ()
    {
	    if(!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
	}
	
	void Update ()
    {
        healthBar.maxValue = victorHealth.maxHealth;
        healthBar.value = victorHealth.currentHealth;
        HPText.text = "HP: " + victorHealth.currentHealth + "/" + victorHealth.maxHealth;
    }
}
