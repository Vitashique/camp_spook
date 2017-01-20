using UnityEngine;
using System.Collections;

public class EatingSoul : MonoBehaviour
{
    private Transform Victor;
    private GameObject Victor2;
    public Rigidbody soul;
    private const float deathRadius = 0.5f;
    private AstarAI botDead;
    private bool isDead;
    private int counter;
    private GameObject[] listOfBots;
  
    private bool b_activatedSoul;
  


    void Start ()
    {
        Victor2 = GameObject.FindWithTag("Player");
        Victor = Victor2.transform;
        Destroy(this.gameObject, 15.0f);
    }




    void Update()
    {
        Vector3 distanceToVictor = Victor.position - this.transform.position;
        float distSq = distanceToVictor.sqrMagnitude;

        //Debug.Log(distSq + ", " + deathRadius);

        if (Input.GetButtonUp("Kill") && distSq < deathRadius && b_activatedSoul == false)
        {

            listOfBots = GameObject.FindGameObjectsWithTag("bot");
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            b_activatedSoul = true;
            Victor2.GetComponent<Victor>().pauseVictorMovement(true);

            for (int i = 0; i < listOfBots.Length-1; i++)
            {
                if(listOfBots[i].name == "BotContainer")
                {
                   //sets new location of where bots want to go to soul location
                    listOfBots[i].GetComponent<AstarAI>().setNewTarget(this.gameObject.transform);
                }
                
            }



        }

        //only when soul has been activated do we start counting
        if (b_activatedSoul)
        {
            counter++;

            //dont Move For xseconds
            if (counter > 200)
            {
                Victor2.GetComponent<VictorHealth>().giveHealth(20);
                b_activatedSoul = false;
                Victor2.GetComponent<Victor>().pauseVictorMovement(false);
                Destroy(this.gameObject);
            }
        }







    }
}
