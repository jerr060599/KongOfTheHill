using UnityEngine;
using System.Collections;

public class Button : Activatable
{
	public float coolDown = 1f;
	float time;

	public override void init ()
	{
	}

	public override void activate (CharControl player)
	{
		if (time <= 0f) {
			sr.sprite = deactivatedTex;
			time = coolDown;
			if (nextActivatable != null)
				nextActivatable.activate (player);
		}
	}

	void Update ()
	{
		time -= Time.deltaTime;
		if (time <= 0f && sr.sprite != activatedTex)
			sr.sprite = activatedTex;
	}
}
