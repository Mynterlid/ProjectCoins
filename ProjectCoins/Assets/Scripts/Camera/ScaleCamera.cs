
using System;
using Unity.VisualScripting;
using UnityEngine;

public class ScaleCamera : MonoBehaviour
{
    [SerializeField][Range(1.3f, 5.0f)] private float _minCameraSize;
    [SerializeField][Range(5.0f, 15.0f)] private float _maxCameraSize;
    [SerializeField][Range(0.01f, 0.3f)] private float _rangeScaleCamera;
    
    private void Update()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (mouseScroll > 0.1)
        {
            ChangeCameraSize(-_rangeScaleCamera);
        }
        if (mouseScroll < -0.1)
        {
            ChangeCameraSize(_rangeScaleCamera);
        }
    }

    private void ChangeCameraSize(float sizeScroll)
    {
        var actualSize = gameObject.GetComponent<Camera>().orthographicSize;
        if (actualSize + sizeScroll < _minCameraSize
            || actualSize + sizeScroll > _maxCameraSize)
        {
            return;
        }
        
        if (actualSize >= _minCameraSize && actualSize <= _maxCameraSize)
        {
            gameObject.GetComponent<Camera>().orthographicSize = actualSize + sizeScroll;
        }
    }
    
    
}
