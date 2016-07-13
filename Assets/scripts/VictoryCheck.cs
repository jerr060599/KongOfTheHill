using UnityEngine;
using System.Collections;

public class VictoryCheck : Activatable
{
	public Sprite neutral;
	public GameObject blueLight, orangeLight, text;
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
		text.GetComponent<UnityEngine.UI.Text> ().text = player.player == 0 ? "Orange has won!" : "Blue has won!";
		text.GetComponent<UnityEngine.UI.Text> ().enabled = true;
	}

	public void disown ()
	{
		sr.sprite = neutral;
		orangeLight.SetActive (false);
		blueLight.SetActive (false);
		GetComponent<Animator> ().SetInteger ("state", -1);
	}
}
