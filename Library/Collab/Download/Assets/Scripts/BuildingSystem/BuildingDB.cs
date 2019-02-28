using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDB: MonoBehaviour{

	public int maxCountBuilding;
	public GameObject[] platforms;
	public Building[] buildings;
	public GameObject[] cityTemplates; 

	void Start()
	{
		Debug.Log ("Init BuildingDB");
		buildings = new Building[maxCountBuilding];
		for (int i = 0; i < maxCountBuilding; i++) 
		{
			buildings[i] = null;
		}
		platforms = GameObject.FindGameObjectsWithTag ("Platforms");
		for (int i_platform = 0, i_building=0; i_platform < platforms.Length && i_building < cityTemplates.Length; i_platform++) 
		{
			if (platforms [i_platform].GetComponent<PlatformController> ().gethasBuilding ()) 
			{
				createBuilding (cityTemplates[i_building],i_platform);
				i_building+=1;
			}
		}
		deactivatePlatforms ();
	}

	void Update()
	{
	}

    public void createBuilding(GameObject building, int position)
	{
		Debug.Log ("Start build " + building.name + " at platform " + position);
		if (buildings [position] != null) 
		{
			Debug.Log ("Destroy " + position);
			destroyBuilding (position);
		}	
		Debug.Log ("Get position " + position);
		Vector3 platform_position = platforms [position].transform.position;
		Quaternion platform_rotation = platforms [position].transform.rotation;
		GameObject currentBuild = (GameObject)Instantiate(building, platform_position, platform_rotation);
		platforms [position].GetComponent<PlatformController> ().setHasBuilding (true);

		Building currentBuildingInfo = currentBuild.GetComponent<Building> ();
		buildings[position] = currentBuildingInfo;
		Debug.Log ("Build success " + position);
	}

	public void destroyBuilding(int position)
	{
		Destroy (buildings [position].gameObject);
		buildings [position] = null;
		Debug.Log ("Destroy success " + position);
	}

	public void activatePlatforms()
	{
		foreach (GameObject platform in platforms) 
		{
			platform.SetActive (true);
		}
	}

	public void deactivatePlatforms()
	{
		foreach(GameObject ob in platforms)
		{
			if (!ob.GetComponent<PlatformController> ().gethasBuilding()) 
			{
				ob.SetActive (false);
			}
		}
	}

}
