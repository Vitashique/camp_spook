using UnityEngine;
using System.Collections;

public class PausedMenu : MonoBehaviour {

    public GameObject pause_menu;
    private bool b_isActive;
    private bool b_onceWasTrue;

	// Use this for initialization
	void Start () {
        b_isActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        //for play button to work on play button code
        if (!pause_menu.active && b_onceWasTrue)
        {
            
            b_isActive = false;
            b_onceWasTrue = false;
            Time.timeScale = 1;
            AudioListener.volume = 1f;
        }

        //if escape is pressed without the menu being up
        if (Input.GetKeyUp(KeyCode.Escape) && b_isActive == false)
        {
            //make sure menu doesn't come up when game over it displayed
            if (GlobalVariables.botAmount > 0)
            {
                pause_menu.SetActive(true);
                b_isActive = true;
                Time.timeScale = 0;
                AudioListener.volume = .2f;
                b_onceWasTrue = true;
            }
        }
        //if escape is pressed with the menu being up
        else if ((Input.GetKeyUp(KeyCode.Escape) && b_isActive == true))
        {

            pause_menu.SetActive(false);
            b_isActive = false;
            Time.timeScale = 1;
            AudioListener.volume = 1f;
            b_onceWasTrue = false;
        }


    }


}
