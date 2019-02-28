using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public bool hasBuilding;

	public Material platfromWithBuilding;
	public Material choosedPlatform;
	public Material defaultPlatform;

	private MeshRenderer meshRender;

	// Use this for initialization
	void Start () {
		meshRender = gameObject.GetComponent<MeshRenderer> ();
	}

	public void setHasBuilding(bool hasBuilding)
	{
		this.hasBuilding = hasBuilding;
	}

	public bool gethasBuilding()
	{
		return this.hasBuilding;
	}

	public void choosePlatfrom()
	{
		meshRender.material = choosedPlatform;
	}

	public void unchoosePlatform()
	{
		if (hasBuilding) 
		{
			meshRender.material = platfromWithBuilding;
		} else 
		{ 
			meshRender.material = defaultPlatform;
		}
	}

}
