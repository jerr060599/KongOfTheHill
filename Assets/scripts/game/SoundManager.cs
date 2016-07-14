using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	public static SoundManager script;
	public AudioClip jump0, jump1, jump2, click0, death0, punch0, climb0, climb1, walk0, walk1, pickup0, checkpoint0, explosion0;

	void Start ()
	{
		script = this;
	}

	public GameObject defSrc;

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
