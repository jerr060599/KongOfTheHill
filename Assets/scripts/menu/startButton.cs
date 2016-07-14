using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startButton : MonoBehaviour {
	GameObject thisStartButton;
	GameObject title;
	GameObject levelSelect;
	UnityEngine.UI.Button start_button;
	bool isMoving;
	bool started;
	int i;

	void ChangeSceneStart() {
		if (!started) {
			isMoving = true;
			started = true;
		}
	}

	// Use this for initialization
	void Start () {
		started = false;
		isMoving = false;
		i = 0;
		thisStartButton = GameObject.FindWithTag ("menuStartButton");
		title = GameObject.FindWithTag ("title");
		levelSelect = GameObject.FindWithTag ("levelSelect");
		start_button = GetComponent<UnityEngine.UI.Button> ();
		start_button.onClick.AddListener (ChangeSceneStart);
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			title.transform.position += new Vector3 (40.0f, 0.0f, 0.0f);
			levelSelect.transform.position += new Vector3 (10.0f, 0.0f, 0.0f);
			i++;
		}

		if (i >= 100) {
			isMoving = false;
		}
	}
}
