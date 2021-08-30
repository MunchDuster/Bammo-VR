using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform followTransform;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = followTransform.position;
		transform.rotation = followTransform.rotation;
    }
}
