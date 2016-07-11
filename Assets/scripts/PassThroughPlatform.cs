using UnityEngine;
using System.Collections;

public class PassThroughPlatform : MonoBehaviour
{
	public GameObject c0go, c1go;
	public GameObject c0, c1;
	Collider2D c0c, c1c;
	// Use this for initialization
	void Start ()
	{
		c0c = c0go.GetComponent<Collider2D> ();
		c1c = c1go.GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		c0c.enabled = c1c.enabled = false;
		if (c0.transform.position.y >= transform.position.y + 11f)
			c0c.enabled = true;
		if (c1.transform.position.y >= transform.position.y + 11f)
			c1c.enabled = true;
	}
}
