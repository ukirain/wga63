using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт для управления камерой.
///  Автор: Олег
/// </summary>
/// <returns></returns>

public class CameraControl : MonoBehaviour {

    [Header("Camera tie")]
    public GameObject cameraTie;
    [Header("Camera restriction")]
    public float sensivityCamera = 0.3f;
    public float sensivityRotate = 3f;
    public float speedZoom = 1.5f;
    public float maxZoom = 10f;
    public float minZoom = 2f;
    public Vector3 minCameraPos = new Vector3(-100, 0, -30);
    public Vector3 maxCameraPos = new Vector3(-10, 30, 50);
    private float angleRotate = 0f;
    Camera controlledCamera;
    [Header("Default camera settings")]
    public Vector3 cameraStartPosition = new Vector3(0, 0, 0);
    private Vector3 cameraPosition;
    public Quaternion cameraStartRotation = new Quaternion(0, 0, 0, 0);
    private Quaternion cameraRotation;
    private Vector3 mousePosition;
    public bool isOnZoom = true;
    public bool isRotate = true;
    public bool isLock = false;
 
    void Start()
	{
        cameraTie.SetActive(false);
        controlledCamera = GetComponent<Camera>();
        controlledCamera.transform.position = cameraStartPosition;
        cameraPosition = cameraStartPosition;
        cameraRotation = cameraStartRotation;
    }

    void Update()
	{
        if (Time.timeScale != 0) {
            mousePosition = Input.mousePosition;
            if (Input.GetMouseButton(1) && isRotate) {
                CameraRotate();
            }
            else {
                CameraMovementByMouse();
                Constraints();
            }
        }
    }

    void FixedUpdate ()
	{
		
	}

    private void CameraMovementByMouse() 
	{
        if(mousePosition.x <= 0)
		{
            //isLock = false;
            controlledCamera.transform.position -=  controlledCamera.transform.right * sensivityCamera;
        }

        if (mousePosition.x >= Screen.width) 
		{
            //isLock = false;
            controlledCamera.transform.position += controlledCamera.transform.right * sensivityCamera;
        }

        if (mousePosition.y <= 0) 
		{
            //isLock = false;
            controlledCamera.transform.position -= cameraTie.transform.up * sensivityCamera;
        }

        if (mousePosition.y >= Screen.height - 5) 
		{
            //isLock = false;
            controlledCamera.transform.position += cameraTie.transform.up * sensivityCamera;
        }

        if (isOnZoom) 
		{
            float zoom = (Input.GetAxis("Mouse ScrollWheel"));
            controlledCamera.transform.position += controlledCamera.transform.forward * zoom * speedZoom;
            if ((controlledCamera.transform.position.y > maxZoom) || (controlledCamera.transform.position.y < minZoom)) {
                controlledCamera.transform.position -= controlledCamera.transform.forward * zoom * speedZoom;
            }
        }
    }

    private void CameraRotate()
	{
        angleRotate = 0f;
        angleRotate = sensivityRotate * ((mousePosition.x - (Screen.width / 2)) / Screen.width);
        controlledCamera.transform.RotateAround(cameraTie.transform.position, Vector3.up, angleRotate);
        cameraRotation = controlledCamera.transform.rotation;
    }

    private void Constraints()
	{
	if (controlledCamera.transform.position.x > maxCameraPos.x)
	{     
            controlledCamera.transform.position = new Vector3(maxCameraPos.x, controlledCamera.transform.position.y, controlledCamera.transform.position.z);
	}

        if (controlledCamera.transform.position.y > maxCameraPos.y)
	{
            controlledCamera.transform.position = new Vector3(controlledCamera.transform.position.x, maxCameraPos.y, controlledCamera.transform.position.z);
        }

        if (controlledCamera.transform.position.z > maxCameraPos.z) 
	{
            controlledCamera.transform.position = new Vector3(controlledCamera.transform.position.x, controlledCamera.transform.position.y, maxCameraPos.z);
        }

        if (controlledCamera.transform.position.x < minCameraPos.x) 
	{
            controlledCamera.transform.position = new Vector3(minCameraPos.x, controlledCamera.transform.position.y, controlledCamera.transform.position.z);
        }

        if (controlledCamera.transform.position.y < minCameraPos.y) 
	{
            controlledCamera.transform.position = new Vector3(controlledCamera.transform.position.x, minCameraPos.y, controlledCamera.transform.position.z);
        }

        if (controlledCamera.transform.position.z < minCameraPos.z) 
	{
            controlledCamera.transform.position = new Vector3(controlledCamera.transform.position.x, controlledCamera.transform.position.y, minCameraPos.z);
        }

    }


    public void Set(Vector3 pPosition) {
        controlledCamera.transform.position = pPosition;
    }
}
