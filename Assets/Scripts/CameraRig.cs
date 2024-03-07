using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
    
    [SerializeField]
    protected Transform trackingTarget;

    void Update()
    {
        transform.position = new Vector3(trackingTarget.position.x + xOffset, trackingTarget.position.y + xOffset, transform.position.z);
    }
}
