using UnityEngine;
using System.Collections;

public class Checkpoint : Activatable
{
	public Sprite blue, orange, neutral;
	Checkpoint tmp;
	CharControl curOwner = null;

	public override void activate (CharControl player)
	{
		if ((tmp = player.curSpawn.GetComponent<Checkpoint> ()) != null)
			tmp.disown ();
		if (curOwner != null)
			curOwner.curSpawn = curOwner.baseSpawn;
		curOwner = player;
		sr.sprite = player.player == 0 ? orange : blue;
		player.curSpawn = gameObject;
	}

	public void disown ()
	{
		sr.sprite = neutral;
	}
}
