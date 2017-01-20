using UnityEngine;
using System.Collections;

public class AstarAI : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    public GameObject spotlight_r;
    public GameObject spotlight_l;
    public GameObject spotlight_u;
    public GameObject spotlight_d;


    public Transform knockPrefab;
    private NavMeshAgent navComponent;
    public Vector3 targetLoc; //target's location at knock
    private Vector3 moveDirection; //bot's move direction/velocity
    private Animator childAnimator;
    private bool knock;
    private bool arrived;
    private bool b_randOnTheWay;

    private GameObject[] beacons;
    private int randBeaconPicker;
    public bool b_isDead;
    private int botDirection;

    void Start()
    {
        navComponent = this.transform.GetComponent<NavMeshAgent>();
        childAnimator = this.GetComponentInChildren<Animator>();
        knock = false;
        beacons = GameObject.FindGameObjectsWithTag("Beacon");
    }

    void Update()
    {      
        if (!b_isDead)
        {
            //when w is pressed
            if (Input.GetButtonDown("Knock"))
            {
                knockPrefab = GameObject.FindGameObjectWithTag("Player").transform;
                target = knockPrefab;
                targetLoc = target.position;
                navComponent.SetDestination(targetLoc);
            }

            //actual movement
            float xMove = moveDirection.x;
            float yMove = moveDirection.z;
            moveDirection = navComponent.velocity;

            //animation code
            //animation code for bot, takes priority in x in over .5, if not then just plays the up or down animation
            if (System.Math.Abs(xMove) > System.Math.Abs(yMove))
            {
                childAnimator.SetFloat("MoveY", 0);
                if (xMove > .1)
                {
                    this.childAnimator.SetFloat("MoveX", 1);
                    botDirection = 1;  //bot moving right
                    this.spotlight_r.SetActive(true);
                    this.spotlight_l.SetActive(false);
                    this.spotlight_u.SetActive(false);
                    this.spotlight_d.SetActive(false);
                }
                else if (xMove < -.1)
                {
                    this.childAnimator.SetFloat("MoveX", -1);
                    botDirection = 2;  //bot moving left
                    this.spotlight_r.SetActive(false);
                    this.spotlight_l.SetActive(true);
                    this.spotlight_u.SetActive(false);
                    this.spotlight_d.SetActive(false);
                }
            }
            else
            {
                childAnimator.SetFloat("MoveX", 0);
                if (yMove > .1f)
                {

                    this.childAnimator.SetFloat("MoveY", 1);
                    botDirection = 3;  //bot moving up
                    this.spotlight_r.SetActive(false);
                    this.spotlight_l.SetActive(false);
                    this.spotlight_u.SetActive(true);
                    this.spotlight_d.SetActive(false);
                }
                else if (yMove < -.1f)
                {
                    this.childAnimator.SetFloat("MoveY", -1);
                    botDirection = 4;  //bot moving down
                    this.spotlight_r.SetActive(false);
                    this.spotlight_l.SetActive(false);
                    this.spotlight_u.SetActive(false);
                    this.spotlight_d.SetActive(true);
                }
            }
            //ANIMATION END

            if (Mathf.Abs(Vector3.Distance(targetLoc, this.transform.position)) < .01)
            {
                b_randOnTheWay = false;
            }

            //set destination 
            if (b_randOnTheWay == false)
            {
                b_randOnTheWay = true;
                randBeaconPicker = Random.Range(0, beacons.Length - 1);//random beacon to go to
                navComponent.SetDestination(beacons[randBeaconPicker].transform.position);
            }

            //stop animation when destination is reached
            if (xMove == 0 && yMove == 0)
            {
                b_randOnTheWay = false;
                childAnimator.SetFloat("MoveX", 0);
                childAnimator.SetFloat("MoveY", 0);
                spotlight_r.SetActive(false);
                spotlight_l.SetActive(false);
                spotlight_u.SetActive(false);
                spotlight_d.SetActive(true);
            }  

            //DIAGONALS
            //(1, 1) = up & right
            //(-1, 1) = up & left
            //(1, -1) = down & right
            //(-1, -1) = down & left

            //STRAIGHT
            //(0, 1) = up
            //(0 -1) = down
            //(1, 0) = right
            //(-1, 0) = left
        }
    }

    //receives a call from bots.c script to activate
    public void dead()
    {
        b_isDead = true;
        /*this.rb.constraints = RigidbodyConstraints.FreezePositionX;
        this.rb.constraints = RigidbodyConstraints.FreezePositionY;
        this.rb.constraints = RigidbodyConstraints.FreezePositionZ;*
        this.rb.isKinematic = true;*/
        this.GetComponent<NavMeshAgent>().speed = -1f;        
    }


    public void setNewTarget(Transform goHere)
    {
       // Debug.Log("1: " + targetLoc);
        target = goHere;
        targetLoc = goHere.position;
        navComponent.SetDestination(targetLoc);
       // Debug.Log("2: " + targetLoc);

    }

   
}