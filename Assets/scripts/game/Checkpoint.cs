﻿using UnityEngine;
using System.Collections;

public class Checkpoint : Activatable
{
	public Sprite neutral;
	public GameObject blueLight, orangeLight;
	Checkpoint tmp;
	CharControl curOwner = null;

	public override void activate (CharControl player)
	{
		if (player == curOwner)
			return;
		if ((tmp = player.curSpawn.GetComponent<Checkpoint> ()) != null)
			tmp.disown ();
		if (curOwner != null)
			curOwner.curSpawn = curOwner.baseSpawn;
		curOwner = player;
		orangeLight.SetActive (false);
		blueLight.SetActive (false);
		(player.player == 0 ? orangeLight : blueLight).SetActive (true);
		GetComponent<Animator> ().SetInteger ("state", player.player);
		player.curSpawn = gameObject;
		SoundManager.script.playOnListener (SoundManager.script.checkpoint0, 0.5f);
		if (nextActivatable != null)
			nextActivatable.activate (player);
	}

	public void disown ()
	{
		sr.sprite = neutral;
		GetComponent<Animator> ().SetInteger ("state", -1);
		orangeLight.SetActive (false);
		blueLight.SetActive (false);
		GetComponent<Animator> ().SetInteger ("state", -1);
	}
}
