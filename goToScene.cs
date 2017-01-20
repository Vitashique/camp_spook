using UnityEngine;
using System.Collections;

//abstract script that will allow when object is pressed to go to another scene
public class goToScene : MonoBehaviour {

	public string StrSceneToGoTo; //allows anyone to enter which scene to go to
	public float alphaValOnClickDown;

	private bool b_mouseOnButton;


	void Start () {
        
	}

    //test

	void Update () {

		//left click down
		if (Input.GetMouseButtonDown (0) && b_mouseOnButton == true) {
			Color tmp = gameObject.GetComponent<SpriteRenderer> ().color;
			tmp.a = alphaValOnClickDown;

			this.GetComponent<SpriteRenderer> ().color = tmp;
		}


		//left click Up
		if (Input.GetMouseButtonUp (0)) {

			if (b_mouseOnButton == true) {
				Application.LoadLevel (StrSceneToGoTo);
			} else {
				//make button alpha to 1 since mouse is away from button
				Color tmp = gameObject.GetComponent<SpriteRenderer> ().color;
				tmp.a = 1;

				this.GetComponent<SpriteRenderer> ().color = tmp;
			}
		}
	
	}

	void OnMouseEnter()
	{
		b_mouseOnButton = true;
		Debug.Log ("Enter");

	}
	void OnMouseExit()
	{
		b_mouseOnButton = false;
		Debug.Log ("EXIT");

	}
}
