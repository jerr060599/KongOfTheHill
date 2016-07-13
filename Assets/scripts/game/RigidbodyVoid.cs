﻿using UnityEngine;
using System.Collections;

public class RigidbodyVoid : MonoBehaviour
{
	public void OnTriggerEnter2D (Collider2D c)
	{
		if (c.attachedRigidbody != null)
		if (c.attachedRigidbody.gameObject.GetComponent<CharControl> () == null)
			Destroy (c.gameObject);
	}
}
