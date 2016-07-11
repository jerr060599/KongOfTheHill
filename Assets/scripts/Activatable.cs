using UnityEngine;
using System.Collections;

public abstract class Activatable : MonoBehaviour
{
	public bool activated = false;
	public GameObject chainedActivatable = null;
	public Sprite activatedTex, deactivatedTex;
	Activatable nextActivatable = null;
	SpriteRenderer sr;

	void Start ()
	{
		sr = GetComponent<SpriteRenderer> ();
		if (activated)
			sr.sprite = activatedTex;
		else
			sr.sprite = deactivatedTex;
		if (chainedActivatable != null)
			nextActivatable = chainedActivatable.GetComponent<Activatable> ();
	}

	public void activate ()
	{
		if (activated) {
			sr.sprite = deactivatedTex;
			activated = false;
			onDeactivation ();
		} else {
			sr.sprite = activatedTex;
			activated = true;
			onActivation ();
		}
		if (nextActivatable != null)
			nextActivatable.activate ();
	}

	public abstract void onActivation ();

	public abstract void onDeactivation ();
}
