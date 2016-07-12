﻿using UnityEngine;
using System.Collections;

public class TwoStopMover : MonoBehaviour
{
	public float x2, y2;
	public float velocity;
	public float pause;
	float x1, y1, stopTime, dx, dy;
	bool toPointOne = false;
	Rigidbody2D pysc;
	// Use this for initialization
	void Start ()
	{
		x1 = transform.position.x;
		y1 = transform.position.y;
		dx = x2 - x1;
		dy = y2 - y1;
		pysc = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void Update ()
	{
		stopTime -= Time.deltaTime;
		if (stopTime <= 0f) {
			Vector3 dir;
			if (toPointOne)
				dir = new Vector3 (x1 - transform.position.x, y1 - transform.position.y, 0f);
			else
				dir = new Vector3 (x2 - transform.position.x, y2 - transform.position.y, 0f);
			if (pysc.velocity.x == 0 && pysc.velocity.y == 0)
				pysc.velocity = dir.normalized * velocity;
			if ((toPointOne ? -1f : 1f) * (dir.x * dx + dir.y * dy) <= 0f) {
				stopTime = pause;
				toPointOne = !toPointOne;
			}
		} else
			pysc.velocity = Vector3.zero;
	}
}
