using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraControl : MonoBehaviour, ICameraPosition
{
    CinemachineFreeLook _fCam;

    private float _screenWidth;
    [SerializeField]
    private float _rotSpeed = 5;

    [SerializeField]
    private float _zoomOutMin = 45;
    [SerializeField]
    private float _zoomOutMax = 120;

    public Transform Transform => _fCam.transform;

    public Quaternion Rotation => _fCam.transform.rotation;

    private void Awake()
    {
        _fCam = GetComponent<CinemachineFreeLook>();
        _screenWidth = (float)Screen.width / 2.0f;
    }

    private void Update()
    {
        TouchControl();       
    }

    void TouchControl()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - _screenWidth) / _screenWidth;
                Vector3 rotPosition = new Vector3(-pos.x, 0, 0.0f);
                RotCamera(rotPosition);             
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;
            ZoomCamera(difference * 0.01f);
        }
    }

    void RotCamera(Vector2 dir)
    {
        _fCam.m_XAxis.Value += dir.x * _rotSpeed;
    }

    void ZoomCamera(float increment)
    {
        _fCam.m_Lens.OrthographicSize = Mathf.Clamp(_fCam.m_Lens.OrthographicSize - increment, _zoomOutMin, _zoomOutMax);
    }

    
}

