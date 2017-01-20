using UnityEngine;
using System.Collections;

public class HurtVictor : MonoBehaviour {

    public int damageAmt;
    private GameObject victorGO;
    private Victor victor;
    private bool turnOn;
    private bool b_keepFollowing;

	void Start ()
    {
        victorGO = GameObject.FindGameObjectWithTag("Player");

    }
	
	void Update ()
    {
        turnOn = false;

        if(b_keepFollowing == true)
        {
            this.transform.parent.GetComponentInParent<AstarAI>().setNewTarget(victorGO.transform);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        turnOn = true;
        if (turnOn == true)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<VictorHealth>().continueToTakeDamage(true);

                this.transform.parent.GetComponentInParent<AstarAI>().setNewTarget(other.gameObject.transform);
               
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                b_keepFollowing = true;


            }
        }
    }
    void OnTriggerExit()
    {
        b_keepFollowing = false;
        victorGO.GetComponent<VictorHealth>().continueToTakeDamage(false);
    }
}
