using UnityEngine;
using System.Collections;

public abstract class Consumable : MonoBehaviour
{
	public Sprite icon;

	void OnTriggerEnter2D (Collider2D c)
	{
		CharControl cc;
		if ((cc = c.attachedRigidbody.gameObject.GetComponent<CharControl> ()) != null)
			cc.eat (this);
	}

	public abstract void onConsumption (GameObject player);
}
