using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    //The offset from the coordinates of the transform to where the camera should focus.
    [SerializeField] private Vector3 offSet;

    public float cameraDistance = 5;
    public float cameraHeight = 7;
    
    private Vector2 _2DSize;
}
