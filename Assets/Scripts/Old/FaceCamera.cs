using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
	public Transform lookToCamera;
	public Vector3 angleOffset;
	// Update is called once per frame
	void Update()
    {
		transform.LookAt(lookToCamera);
		transform.Rotate(angleOffset);
	}
}
