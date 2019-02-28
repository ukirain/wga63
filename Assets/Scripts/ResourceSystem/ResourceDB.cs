using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDB : MonoBehaviour{

	public float water;
	public float money;
	public int mechanics;
	public int people;

	public float waterRepeatUpdater;
	public float moneyRepeatUpdater;
	public int mechanicsRepeatUpdater;
	public int peopleRepeatUpdater;

	/*public ResourceDB (float water, float money, int mechanics, int people, float waterRepeater, float moneyRepeater, int mechanicsRepeater, int peopleRepeater)
	{
		this.water = water;
		this.money = money;
		this.mechanics = mechanics;
		this.people = people;

		this.waterRepeatUpdater = waterRepeater;
		this.moneyRepeatUpdater = moneyRepeater;
		this.mechanicsRepeatUpdater = mechanicsRepeater;
		this.peopleRepeatUpdater = peopleRepeater;

	}

	public void updateAllResourcesRepeat()
	{
		water += waterRepeatUpdater;
		money += moneyRepeatUpdater;
		mechanics += mechanicsRepeatUpdater;
		people += peopleRepeatUpdater;
	}

	public void updateWater(float water)
	{
		this.water += water;
	}

	public void updateMoney(float money)
	{
		this.money += money;
	}

	public void updateMechanics(int mechanics)
	{
		this.mechanics += mechanics;
	}

	public void updatePeople(int people)
	{
		this.people += people;
	}



	public void updateRepeatWater(float water)
	{
		this.waterRepeatUpdater += water;
	}

	public void updateRepeatMoney(float money)
	{
		this.moneyRepeatUpdater += money;
	}

	public void updateRepeatMechanics(int mechanics)
	{
		this.mechanicsRepeatUpdater += mechanics;
	}

	public void updateRepeatPeople(int people)
	{
		this.peopleRepeatUpdater += people;
	}

	public void updateAllRepeaters(float water, float money, int mechanics,int people)
	{
		this.waterRepeatUpdater += water;
		this.moneyRepeatUpdater += money;
		this.mechanicsRepeatUpdater += mechanics;
		this.peopleRepeatUpdater += people;
	}

	public override string ToString ()	
	{
		return string.Format ("[Resources: water={0}, money={1}, mechanics={2}, people={3}, waterRepeatUpdater={4}, moneyRepeatUpdater={5}, mechanicsRepeatUpdater={6}, peopleRepeatUpdater={7}]", water, money, mechanics, people, waterRepeatUpdater, moneyRepeatUpdater, mechanicsRepeatUpdater, peopleRepeatUpdater);
	}
	
	public void logging()
	{
		Debug.Log (this.ToString());
	}*/

}
