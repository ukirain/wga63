using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TownController : MonoBehaviour {

	public int smooth;
	private const float DistanceRay = 10000.0f;
	private Vector3 targetPosition;
    private Vector2 to;
	public Properties properties;
    public CameraControl cameraControl;
    public GameObject otherTown; //создать пул объектов, чтобы все работало автоматически
    public Functions f;
	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
	}

	// Update is called once per frame6
	void Update () {
        if (Time.timeScale != 0) {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && properties.getGameState() == GameState.MOVEMENT) {
                RaycastHit hit;
                Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, DistanceRay)) {
                    targetPosition.x = hit.point.x;
                    targetPosition.y = hit.point.y;
                    to.x = (targetPosition.x - this.transform.position.x)
                        / (float)System.Math.Sqrt((this.transform.position.x - targetPosition.x) * (this.transform.position.y - targetPosition.y) * (this.transform.position.x - targetPosition.x) * (this.transform.position.y - targetPosition.y));
                    to.y = (targetPosition.y - this.transform.position.y) 
                        / (float)System.Math.Sqrt((this.transform.position.x - targetPosition.x) * (this.transform.position.y - targetPosition.y) * (this.transform.position.x - targetPosition.x) * (this.transform.position.y - targetPosition.y));
                    Debug.Log("Hit " + targetPosition);
                }
                cameraControl.isLock = true;
            } else {
                if(this.transform.position.x - targetPosition.x != 0)
                    targetPosition.x = targetPosition.x + to.x;
                if (this.transform.position.y - targetPosition.y != 0)
                    targetPosition.y = targetPosition.y + to.y;
                //Debug.Log((to));
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * smooth * (float)f.v * 0.1f);
            if (Input.GetKeyDown(KeyCode.Q)) {
                if (cameraControl.isLock) { //сделано для переноса камеры к объекту
                    const int deltaZ = 40;
                    Vector3 newPositionCamera = new Vector3(transform.position.x, transform.position.y, transform.position.z - deltaZ);
                    cameraControl.Set(newPositionCamera);
                }
            }
        }
        //fogOfWar();

    }

	public void stop(){
		targetPosition = transform.position;
	}

	public void move(Vector3 targetPosition){
		this.targetPosition = targetPosition;
	}

    

    void OnTriggerEnter2D(Collider2D other) {
        
    }
}
