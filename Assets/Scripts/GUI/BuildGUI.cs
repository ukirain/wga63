using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildGUI : MonoBehaviour {

	public bool BuildMod;
	public GameObject buildingSystem;
	public LayerMask Mask;
	public GameObject[] buildingTemplates;

	private BuildingManager buildingManager;
	private GameObject BuildPanel;
	private GameObject BuildModeList;
	private GameObject BuildCancel;
	private int numberCurrentPlatform;
	private GameObject currentPlatfrom;

	private const float DistanceRay = 10000f;

	void Start () 
	{
		
		BuildMod = false;
		numberCurrentPlatform = 0;
		currentPlatfrom = null;
		buildingManager = buildingSystem.GetComponent<BuildingManager> ();
		BuildPanel = GameObject.FindGameObjectWithTag ("BuildPanel");
		BuildModeList = GameObject.FindGameObjectWithTag ("BuildModeList");
		BuildCancel = GameObject.FindGameObjectWithTag ("BuildCancel");
		BuildModeList.SetActive (false);
		BuildCancel.SetActive (false);
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && BuildMod && !EventSystem.current.IsPointerOverGameObject()) {
			RaycastHit hit;
			Ray ray = UnityEngine.Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, DistanceRay)) {
				GameObject[] platforms = buildingManager.getPlatforms ();
				for (int i = 0; i < platforms.Length; i++) {
					if (hit.collider.name.Equals (platforms [i].name)) {
						BuildModeList.SetActive (true);			
						numberCurrentPlatform = i;
						choosePlatform (platforms[i]);
						Debug.Log ("Collision " + platforms [i].name);
						break;
					}
				}
			} else {
				BuildModeList.SetActive (false);
				unchoosePlatform ();
			}
		}
	}

	public void createBuild(int building)
	{
		buildingManager.createBuilding (buildingTemplates[building], numberCurrentPlatform);
	}

	public void destroyBuilding(int position)
	{
		buildingManager.destroyBuilding (position);
	}

	public void choosePlatform(GameObject platform)
	{
		if (currentPlatfrom != null) 
		{
			currentPlatfrom.GetComponent<PlatformController> ().unchoosePlatform ();
		}
		platform.GetComponent<PlatformController> ().choosePlatfrom ();
		currentPlatfrom = platform;
	}

	public void unchoosePlatform()
	{
		if (currentPlatfrom != null) 
		{
			currentPlatfrom.GetComponent<PlatformController> ().unchoosePlatform ();
			currentPlatfrom = null;
		}
	}

	public void activateBuildMod()
	{
		BuildMod = true;
		BuildCancel.SetActive (true);
		buildingManager.activatePlatforms ();
		Debug.Log("Build Mod is active");
	}

	public void deactivateBuildMod()
	{
		BuildMod = false;
		BuildModeList.SetActive (false);
		BuildCancel.SetActive (false);
		if (currentPlatfrom != null) 
		{
			currentPlatfrom.GetComponent<PlatformController> ().unchoosePlatform ();
			currentPlatfrom = null;
		}
		buildingManager.deactivatePlatforms ();
		Debug.Log("Build Mod is deactive");
	}
}
