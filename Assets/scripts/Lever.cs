using UnityEngine;
using System.Collections;

public class Lever : Activatable
{
	// Update is called once per frame
	void Update ()
	{
	}

	public override void onActivation (CharControl player)
	{
		SoundManager.script.playOnListener (SoundManager.script.click0, 0.2f);
	}

	public override void onDeactivation (CharControl player)
	{
		SoundManager.script.playOnListener (SoundManager.script.click0, 0.2f);
	}
}
