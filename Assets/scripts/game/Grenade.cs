using UnityEngine;
using System.Collections;

public class Grenade : Consumable
{
	float r = 40f;

	public override void onConsumption (CharControl player)
	{
		CameraMovement.script.shake ();
		if (player.player == 0) {
			CharControl c1 = GameObject.FindWithTag ("c1").GetComponent<CharControl> ();
			if ((player.pysc.position - c1.pysc.position).sqrMagnitude <= r * r)
				c1.kill ();
		} else {
			CharControl c0 = GameObject.FindWithTag ("c0").GetComponent<CharControl> ();
			if ((player.pysc.position - c0.pysc.position).sqrMagnitude <= r * r)
				c0.kill ();
		}
	}
}
