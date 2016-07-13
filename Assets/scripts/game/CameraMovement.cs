using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public GameObject c0, c1, bg;
	public float sizeScale = 0.55f;
	Vector3 shakePos = Vector3.zero, curPos;
	Camera cam;
	public static CameraMovement script;

	void Start ()
	{
		script = this;
		curPos = transform.position;
		cam = GetComponent<Camera> ();
	}

	void Update ()
	{
		cam.transform.position = (curPos += ((c0.transform.position + c1.transform.position) / 2f - curPos) * 0.1f) + shakePos;
		shakePos *= 0.7f;
		cam.orthographicSize += (Mathf.Max (64f, (c0.transform.position - c1.transform.position).magnitude * sizeScale) - (float)cam.orthographicSize) * 0.1f;
		bg.transform.localScale = new Vector3 (cam.orthographicSize, cam.orthographicSize, 1f) / 64f;
	}

	public void shake ()
	{
		shakePos = new Vector3 (Random.value, Random.value, 0f).normalized * 10f;
	}
}
