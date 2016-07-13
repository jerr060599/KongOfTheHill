using UnityEngine;
using System.Collections;

public class PassThroughPlatform : MonoBehaviour
{
	public GameObject c0go, c1go;
	GameObject c0, c1;
	Collider2D c0c, c1c;
	// Use this for initialization
	void Start ()
	{
		c0 = GameObject.FindWithTag ("c0");
		c1 = GameObject.FindWithTag ("c1");
		c0c = c0go.GetComponent<Collider2D> ();
		c1c = c1go.GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		c0c.enabled = c1c.enabled = false;
		if (!Input.GetKey (Settings.keys [0, Settings.down]) && c0.transform.position.y >= transform.position.y + 11.9f)
			c0c.enabled = true;
		if (!Input.GetKey (Settings.keys [1, Settings.down]) && c1.transform.position.y >= transform.position.y + 11.9f)
			c1c.enabled = true;
		
	}
}
