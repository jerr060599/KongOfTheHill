using UnityEngine;
using System.Collections;

public class Lever : Activatable
{
	// Update is called once per frame
	void Update ()
	{
	}

	public void onActivation (CharControl player)
	{
		Debug.Log ("Turned On");
	}

	public void onDeactivation (CharControl player)
	{
		Debug.Log ("Turned Off");
	}
}
