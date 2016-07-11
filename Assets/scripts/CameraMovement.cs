using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public GameObject c0, c1;
	float sizeScale = 0.5f;
	Camera cam;

	void Start ()
	{
		cam = GetComponent<Camera> ();
	}

	void Update ()
	{
		gameObject.transform.position += ((c0.transform.position + c1.transform.position) / 2f - gameObject.transform.position) * 0.1f;
		cam.orthographicSize += (Mathf.Max (64f, (c0.transform.position - c1.transform.position).magnitude * sizeScale) - (float)cam.orthographicSize) * 0.1f;
	}

}
