using UnityEngine;
using System.Collections;

public class PauseMenuOptions : MonoBehaviour {

    //0 for restart
    //1 for main menu
    //2 for exit

    public int optionType;
    public string goToSceneHome = "Start Menu";
    public string goToSceneRestart = "Level 1";
    public GameObject pausedMenuParent;
    private bool b_mouseOnButton;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0) && b_mouseOnButton == true)
        {
            if (optionType == 0)
            {

   

                pausedMenuParent.SetActive(false);
                




            }
            else if(optionType == 1)
            {

                //main menu
                Application.LoadLevel(goToSceneRestart);


            }
            else if(optionType == 2)
            {

                Application.LoadLevel(goToSceneHome);
            }
            
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
