using UnityEngine;
using System.Collections;

public class RollRedirect : MonoBehaviour
{
	public float scaler = 1f;

	public void OnTriggerEnter2D (Collider2D c)
	{
		ConstantRoll cr;
		if ((cr = c.gameObject.GetComponent<ConstantRoll> ()) != null)
			cr.w *= scaler;
	}
}
