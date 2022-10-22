using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    private void FixedUpdate()
    {
        Debug.Log(followTransform.position.z);
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, -10);
    }
}
