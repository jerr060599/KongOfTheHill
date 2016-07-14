using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class helpButton : MonoBehaviour {
	GameObject thisHelpButton;
	UnityEngine.UI.Button help_button;

	void ChangeSceneHelp() {
		Application.LoadLevel ("tutorial");
	}

	// Use this for initialization
	void Start () {
		thisHelpButton = GameObject.FindWithTag ("menuHelpButton");
		help_button = GetComponent<UnityEngine.UI.Button> ();
		help_button.onClick.AddListener (ChangeSceneHelp);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
