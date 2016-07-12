using UnityEngine;
using System.Collections;

public class KillOnTouch : MonoBehaviour
{
	// Use this for initialization
	void OnCollisionEnter2D (Collision2D c)
	{
		CharControl cc = c.collider.attachedRigidbody.gameObject.GetComponent<CharControl> ();
		if (cc != null)
			cc.kill ();
	}
}
