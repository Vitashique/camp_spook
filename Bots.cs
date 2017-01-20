using UnityEngine;
using System.Collections;

public class Bots : MonoBehaviour
{
    public GameObject bot;
    public Transform botTrans;
    public Transform soulPrefab;
    public GameObject victor;
    public GameObject light;
    public Renderer rend;

    private GameObject holderOfSoul;
    private const float deathRadius = 1f;
    private const float deathRadiusSQ = deathRadius * deathRadius;
    private Animator animator;
    private bool b_isDead;
    private bool eatenSoul;

    private float movingUp;
    private float movingDown;

    public static int botAmount; //the total amount of bots not dead

    void Start()
    {
        GlobalVariables.botAmount++;
        bot = GameObject.FindWithTag("bot");
        victor = GameObject.Find("Victor");
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Update()
    {
        
        if (Input.GetButtonUp("Kill") && b_isDead == false)
        {
            //make it so victor's position is given for all the bots to run down when kill is hit
            this.GetComponentInParent<AstarAI>().setNewTarget(victor.transform);
            Vector3 distanceToVictor = victor.transform.position - this.transform.position;
            if (distanceToVictor.sqrMagnitude <= deathRadiusSQ)
            {
                
                Color tmp = this.gameObject.GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;

                this.GetComponent<SpriteRenderer>().color = tmp;
                light.SetActive(false);             

                //animator.SetFloat("MoveX", 0);
                //animator.SetFloat("MoveY", 0);
                //animator.SetBool("isAlive", false);

                this.gameObject.GetComponentInParent<AstarAI>().dead();

                this.GetComponent<Animator>().enabled = false;
                turnOffChildren();
                b_isDead = true;
                GlobalVariables.botAmount--;

                //instantiate soul at dead bot's location/position
                
                holderOfSoul = Instantiate(soulPrefab, this.botTrans.position, transform.rotation) as GameObject;
                

            }
        }
    }

    void turnOffChildren()
    {
        for (int i = 0; i < this.transform.GetChildCount(); ++i)
        {
            if (this.transform.GetChild(i).name == "bloodsplat3_strip15_0")
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        rend.enabled = false;
    }
}