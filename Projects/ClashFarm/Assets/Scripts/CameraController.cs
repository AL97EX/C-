using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;

    [Header("Camera Clamp")]
    [SerializeField] private float _minCameraClamp;
    [SerializeField] private float _maxCameraClamp;
    
    [Header("Camera Zoom")]
    [SerializeField] private float _minCameraZoom;
    [SerializeField] private float _maxCameraZoom;
    private Vector3 _startPos, _targetPos, pos;
    private Camera _cam;
    private float MoveDelta => _speed * Time.deltaTime;

    public bool _isMobilePlatform;


    private void Awake()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE
                _isMobilePlatform = false;
        #else
                _isMobilePlatform = true;
        #endif
    }

    void Start()
    {
        _targetPos = transform.position;
        _cam = GetComponent<Camera>();
    }

    void CameraMoving()
    {
        if (Input.GetMouseButtonDown(0))
            _startPos = _cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            Vector3 pos = _cam.ScreenToWorldPoint(Input.mousePosition) - _startPos;
            _targetPos = new Vector3(Mathf.Clamp(transform.position.x - pos.x, _minCameraClamp, _maxCameraClamp), 0, Mathf.Clamp(transform.position.z - pos.z, _minCameraClamp, _maxCameraClamp));
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x - pos.x, _targetPos.x, MoveDelta),
            transform.position.y,
            Mathf.Lerp(transform.position.z - pos.z, _targetPos.z, MoveDelta));
    }

    void Update()
    {
        CameraMoving();
        
        if (!_isMobilePlatform)
        {
            MouseCameraZoom();
        }

        else if (_isMobilePlatform)
        {
            MobileCameraZoom();
        }

    }

    void MouseCameraZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            CameraZoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void MobileCameraZoom()
    {
        if (Input.touchCount >= 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touchPrevPos0 = touch0.position - touch0.deltaPosition;
            Vector2 touchPrevPos1 = touch1.position - touch1.deltaPosition;

            float currentMagnitude = (touch0.position - touch1.position).magnitude;
            float prevMagnitude = (touchPrevPos0 - touchPrevPos1).magnitude;

            float difference = currentMagnitude - prevMagnitude;
            CameraZoom(difference * 0.01f);
        }
    }

    void CameraZoom(float increment)
    {
        _cam.orthographicSize = Mathf.Clamp(_cam.orthographicSize - increment * _speed, _minCameraZoom, _maxCameraZoom);
    }

    //void CameraMoving()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //        _startPos = _cam.ScreenToWorldPoint(Input.mousePosition);
    //    else if (Input.GetMouseButton(0))
    //    {
    //        Vector3 pos = _cam.ScreenToWorldPoint(Input.mousePosition) - _startPos;
    //        _targetPos = new Vector3(Mathf.Clamp(transform.position.x - pos.x, _minCameraClamp, _maxCameraClamp), 0, Mathf.Clamp(transform.position.z - pos.z, _minCameraClamp, _maxCameraClamp));
    //    }
    //    transform.position = new Vector3(Mathf.Lerp(transform.position.x - pos.x, _targetPos.x, MoveDelta),
    //        transform.position.y,
    //        Mathf.Lerp(transform.position.z - pos.z, _targetPos.z, MoveDelta));
    //}
}
