using UnityEngine;
using System.Collections;

public class FadeButtonOnClick : MonoBehaviour {

    public float alphaValOnClickDown = 0.5f;

    private bool b_mouseOnButton;

    void Update()
    {

        //left click down
        if (Input.GetMouseButtonDown(0) && b_mouseOnButton == true)
        {
            Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
            tmp.a = alphaValOnClickDown;

            this.GetComponent<SpriteRenderer>().color = tmp;

        }


        //left click Up
        if (Input.GetMouseButtonUp(0))
        {

          
                //make button alpha to 1 when mouse is up
                Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
                tmp.a = 1;

                this.GetComponent<SpriteRenderer>().color = tmp;
           
        }

    }

    void OnMouseEnter()
    {
        b_mouseOnButton = true;

    }
    void OnMouseExit()
    {
        b_mouseOnButton = false;
        //

    }
}
