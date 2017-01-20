using UnityEngine;
using System.Collections;

public class VictorDying : MonoBehaviour {

    public GameObject lightHealthBar;
    public GameObject gameOver;
    public GameObject youDidIt;
    public float intensity = .2f;
    public float dyingRate = .005f;
    private int victorHealth = 100;
    private int counterOfDead;
    private bool b_takingDamage = false;
    private bool b_youWin;
   
   

    void Start()
    {
       


    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            b_takingDamage = true;
     
        }

        if (GlobalVariables.botAmount == 0 || Input.GetKeyDown(KeyCode.P))
        {
            youDidIt.SetActive(true);

            AudioListener.volume = .2f;

        }
    


        if (b_takingDamage)
        {
            if (intensity <= 1)
            {
                intensity += dyingRate;
                lightHealthBar.GetComponent<Light>().intensity = intensity;
            }
            else
            {
                //dead
                Debug.Log("YOU MADE IT");
                gameOver.SetActive(true);
            }

        
        }


    }
}
