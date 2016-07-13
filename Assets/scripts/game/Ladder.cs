using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{
	void OnTriggerStay2D (Collider2D c)
	{
		CharControl cc = c.attachedRigidbody.GetComponent<CharControl> ();
		if (cc != null)
			cc.onLadder = true;
	}
}
