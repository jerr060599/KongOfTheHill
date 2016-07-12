using UnityEngine;
using System.Collections;

public class Checkpoint : Activatable
{
	public Sprite blue, orange, neutral;
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
		sr.sprite = player.player == 0 ? orange : blue;
		player.curSpawn = gameObject;
	}

	public void disown ()
	{
		sr.sprite = neutral;
		orangeLight.SetActive (false);
		blueLight.SetActive (false);
	}
}
