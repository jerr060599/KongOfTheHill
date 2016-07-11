using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	public GameObject c0, c1;
	public GameObject defSrc;

	void Update ()
	{
		gameObject.transform.position = new Vector2 (0f, (c0.transform.position.y + c1.transform.position.y) / 2);
	}

	public AudioSource playOnListener (AudioClip clip, float volume = 1f)
	{
		GameObject src = (GameObject)Instantiate (defSrc, transform.position, transform.rotation);
		src.transform.SetParent (gameObject.transform);
		src.GetComponent<AudioSource> ().clip = clip;
		src.GetComponent<AudioSource> ().volume = volume;
		src.GetComponent<AudioSource> ().Play ();
		return src.GetComponent<AudioSource> ();
	}

	public AudioSource playOn (Vector2 pos, AudioClip clip, float volume = 1f)
	{
		GameObject src = (GameObject)Instantiate (defSrc, pos, Quaternion.identity);
		src.GetComponent<AudioSource> ().clip = clip;
		src.GetComponent<AudioSource> ().volume = volume;
		src.GetComponent<AudioSource> ().Play ();
		return src.GetComponent<AudioSource> ();
	}
}
