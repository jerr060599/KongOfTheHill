using UnityEngine;
using System.Collections;

public abstract class Activatable : MonoBehaviour
{
	public bool activated = false;
	public GameObject chainedActivatable = null;
	public Sprite activatedTex, deactivatedTex;
	protected Activatable nextActivatable = null;
	protected SpriteRenderer sr;

	void Start ()
	{
		sr = GetComponent<SpriteRenderer> ();
		if (chainedActivatable != null)
			nextActivatable = chainedActivatable.GetComponent<Activatable> ();
		init ();
	}

	public virtual void init ()
	{
		if (activated)
			sr.sprite = activatedTex;
		else
			sr.sprite = deactivatedTex;
	}

	public virtual void activate (CharControl player)
	{
		if (activated) {
			sr.sprite = deactivatedTex;
			activated = false;
			onDeactivation (player);
		} else {
			sr.sprite = activatedTex;
			activated = true;
			onActivation (player);
		}
		if (nextActivatable != null)
			nextActivatable.activate (player);
	}

	public virtual void onActivation (CharControl player)
	{
	}

	public virtual void onDeactivation (CharControl player)
	{
	}
}
