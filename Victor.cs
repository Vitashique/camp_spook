using UnityEngine;
using System.Collections;

public class Victor : MonoBehaviour
{
    public float moveSpeedConstant;
    public GameObject myPrefab;

    private Animator anim;
    private Rigidbody rigidBody; //important for colliders
    private Vector2 lastMove;
    private bool victorMoving;

    private int counter;
    private bool b_pauseMovement;

    void Start()
    {
        /*bot = GameObject.FindWithTag("bot");
        victor = GameObject.Find("Victor");*/
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Knock"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            GameObject lightGameobj = (GameObject)Instantiate((myPrefab));

            lightGameobj.transform.position = gameObject.transform.position;
            lightGameobj.transform.parent = null;
            Destroy(lightGameobj, 3);

            b_pauseMovement = true;
            counter = 30;
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", 0);
        }

        //pause when knock
        if (counter > 0)
        {
            counter--;
            if (counter == 0)
            {
                b_pauseMovement = false;
            }
        }

        if(b_pauseMovement == false)
        {
            float moveSpeed = moveSpeedConstant;
            float x = rigidBody.position.x;
            float y = 0f;
            float z = rigidBody.position.z;

            //ANIMATION CHANGES BASED ON MOVEMENT LEFT, RIGHT, UP, AND DOWN
            anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxis("Vertical"));

            //movement of Victor based on arrow keys
            //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);         

            //this makes it so that diagonal movement speed is constant with x and y movement speed. Without this, moving diagonally shoots the character's speed up
            float xDir = rigidBody.velocity.x;
            float yDir = rigidBody.velocity.y;

            if (xDir == 1f & yDir == 1f || xDir == -1f && yDir == 1f || xDir == -1f && yDir == -1f || xDir == 1f && yDir == -1f)
            {
                moveSpeed = moveSpeedConstant * 0.5f;
            }

            else
            {
                moveSpeed = moveSpeedConstant;
            }

            //PLAYER MOVEMENT BASED ON ARROW KEYS
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) //if player pressing to right or to the left (respectively)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                //rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigidBody.velocity.y);
                victorMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            //if player is stationary in the horizontal
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
            }

            //if player is stationary in the vertical
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            }

            //if player is pressing up or right
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) //if player pressing up or down (respectively)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                //rigidBody.velocity = new Vector2(rigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                victorMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Vertical"), 0f);
              //  Debug.Log(rigidBody.velocity);
            }
        }
    }//end Update

    public void pauseVictorMovement(bool b_pause)
    {

        b_pauseMovement = b_pause;


        //pause animation
        if (b_pause)
        {
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", 0);
        }

    }

}