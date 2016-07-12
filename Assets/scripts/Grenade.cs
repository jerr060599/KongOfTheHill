using UnityEngine;
using System.Collections;

public class Grenade : Consumable
{
	public override void onConsumption (GameObject player)
	{
		CameraMovement.script.shake ();
	}
}
