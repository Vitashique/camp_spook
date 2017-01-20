using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

    private bool b_mouseOnButton;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0) && b_mouseOnButton == true)
        {
            Application.Quit();
        }

    }

    void OnMouseEnter()
    {
        b_mouseOnButton = true;

    }
    void OnMouseExit()
    {
        b_mouseOnButton = false;

    }
}
