using UnityEngine;
using System.Collections;

public class Grenade : Consumable
{
	float r = 40f;
	public GameObject explosion;
	public override void onConsumption (CharControl player)
	{
		CameraMovement.script.shake ();
		Instantiate (explosion, player.transform.position, player.transform.rotation);
		SoundManager.script.playOnListener (SoundManager.script.explosion0, 1f);
		if (player.player == 0) {
			CharControl c1 = GameObject.FindWithTag ("c1").GetComponent<CharControl> ();
			if ((player.pysc.position - c1.pysc.position).sqrMagnitude <= r * r)
				c1.kill ();
		} else {
			CharControl c0 = GameObject.FindWithTag ("c0").GetComponent<CharControl> ();
			if ((player.pysc.position - c0.pysc.position).sqrMagnitude <= r * r)
				c0.kill ();
		}
		foreach (RaycastHit2D rh in Physics2D.CircleCastAll(player.gameObject.transform.position, r, Vector2.down, 0f))
			if (rh.collider.attachedRigidbody != null && rh.collider.attachedRigidbody.gameObject.GetComponent<ConstantRoll> () != null)
				Destroy (rh.collider.attachedRigidbody.gameObject);
	}
}
