using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	public static bool paused = false;
	CanvasRenderer canvas;
	float alpha = 0f;
	// Use this for initialization
	void Start ()
	{
		Cursor.visible = false;
		canvas = GetComponent<CanvasRenderer> ();
		canvas.SetAlpha (alpha);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (Settings.keys [Settings.ui, Settings.pause])) {
			paused = !paused;
			Time.timeScale = paused ? 0f : 1f;
			alpha = paused ? 0.9f : 0f;
			Cursor.visible = paused;
		}
		canvas.SetAlpha (canvas.GetAlpha () + (alpha - canvas.GetAlpha ()) * 0.1f);
		if (canvas.GetAlpha () < 0.5f)
			GetComponent<Canvas> ().enabled = false;
		else
			GetComponent<Canvas> ().enabled = true;

	}
}
