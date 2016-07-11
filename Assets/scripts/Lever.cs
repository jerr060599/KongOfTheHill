using UnityEngine;
using System.Collections;

public class Lever : Activatable
{
	// Update is called once per frame
	void Update ()
	{
	}

	public override void onActivation ()
	{
		Debug.Log ("Turned On");
	}

	public override void onDeactivation ()
	{
		Debug.Log ("Turned Off");
	}
}
