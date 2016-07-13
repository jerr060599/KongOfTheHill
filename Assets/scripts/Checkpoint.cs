using UnityEngine;
using System.Collections;

public class Checkpoint : Activatable
{
	public Sprite neutral;
	public GameObject blueLight, orangeLight;
	Checkpoint tmp;
	CharControl curOwner = null;

	public override void activate (CharControl player)
	{
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
	}

	public void disown ()
	{
		sr.sprite = neutral;
		orangeLight.SetActive (false);
		blueLight.SetActive (false);
		GetComponent<Animator> ().SetInteger ("state", -1);
	}
}
