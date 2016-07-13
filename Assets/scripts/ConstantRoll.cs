using UnityEngine;
using System.Collections;

public class ConstantRoll : MonoBehaviour
{
	public float w;
	Rigidbody2D pysc;
	// Use this for initialization
	void Start ()
	{
		pysc = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		pysc.angularVelocity = w;
	}
}
