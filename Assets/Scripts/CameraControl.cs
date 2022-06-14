using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a class for camera movement
/// </summary>
public class CameraControl : MonoBehaviour
{
    private Transform _lookAt;
    private readonly float _boundX = 0.15f; // camera bound on the X axis
    private readonly float _boundY = 0.05f; // camera bound on the Y axis

    private void Start()
    {
        _lookAt = GameObject.Find("spaceman").transform;
    }
    /// <summary>
    /// This is a function that is called every frame.
    /// </summary>
    private void LateUpdate()
    {
        if (_lookAt != null)
        {
            Vector3 delta = Vector3.zero;

            float deltaX = _lookAt.position.x - transform.position.x;

            if (deltaX > _boundX || deltaX < -_boundX)
            {
                if (transform.position.x < _lookAt.position.x)
                {
                    delta.x = deltaX - _boundX;
                }
                else
                {
                    delta.x = deltaX + _boundX;
                }
            }

            float deltaY = _lookAt.position.y - transform.position.y;

            if (deltaY > _boundY || deltaY < -_boundY)
            {
                if (transform.position.y < _lookAt.position.y)
                {
                    delta.y = deltaY - _boundY;
                }
                else
                {
                    delta.y = deltaY + _boundY;
                }
            }
            transform.position += new Vector3(delta.x, deltaY, 0);
        }
    } 
}
