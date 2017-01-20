using UnityEngine;
using System.Collections;

public class escPressHide : MonoBehaviour {
    public GameObject creditsMenu; //allows anyone to enter which scene to go to

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            creditsMenu.SetActive(false);
        }
    }
}
