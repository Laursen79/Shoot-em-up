using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraTarget target;
    private Transform targetTransform;

    private void Awake()
    {
        targetTransform = target.transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var newTargetPos = targetTransform.position;
        newTargetPos += -targetTransform.forward * target.cameraDistance + Vector3.up * target.cameraHeight;
        transform.position = newTargetPos;
        transform.LookAt(targetTransform);
    }

}
