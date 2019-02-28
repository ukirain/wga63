using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {
	
	public BuildingDB buildingDB;

	void Start () {
		/*
		//SET RANDOM CITY TEMPLATES
		Vector3 platform_position = new Vector3(0f,0f,0f);
		Quaternion platform_rotation = Quaternion.Angle(0f,0f,0f);
		GameObject currentBuild = (GameObject)Instantiate(cityTemplates[Random.Range (0, 0)], platform_position, platform_rotation);
		foreach (Transform transform in currentBuild.transform) {
			createBuilding (transform.GetComponentsInChildren<Building>(),);
		}
		*/
	}
	
	void Update () {
		
	}

	public void createBuilding(GameObject ob, int position)
	{
		buildingDB.createBuilding (ob, position);
	}

	public void destroyBuilding(int position)
	{
		buildingDB.destroyBuilding (position);
	}

	public void activatePlatforms()
	{
		buildingDB.activatePlatforms ();
	}

	public void deactivatePlatforms()
	{
		buildingDB.deactivatePlatforms ();
	}

	public GameObject[] getPlatforms()
	{
		return buildingDB.platforms;
	}
}
