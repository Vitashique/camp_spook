using UnityEngine;
using System.Collections;

public class p_Movement : MonoBehaviour
{

    public Vector2 velocity;
    public Rigidbody2D rb2D;


    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }


}
