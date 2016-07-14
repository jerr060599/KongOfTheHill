using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class quitButton : MonoBehaviour {
	GameObject thisQuitButton;
	UnityEngine.UI.Button quit_button;

	void Quit() {
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
		thisQuitButton = GameObject.FindWithTag ("menuQuitButton");
		quit_button = GetComponent<UnityEngine.UI.Button> ();
		quit_button.onClick.AddListener (Quit);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
