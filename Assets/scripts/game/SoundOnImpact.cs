using UnityEngine;
using System.Collections;

public class SoundOnImpact : OnImpact
{
	public AudioClip sound;
	public float volume;

	public override void impact ()
	{
		Debug.Log ("Here");
		SoundManager.script.playOnListener (sound, volume);
	}
}
