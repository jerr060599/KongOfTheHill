using UnityEngine;
using System.Collections;

public class Grenade : Consumable
{
	public float r = 10f;
	public override void onConsumption (CharControl player)
	{
		CameraMovement.script.shake ();

	}
}
