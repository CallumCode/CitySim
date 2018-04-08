using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
	Goal m_BaseGoal = null;

	Need m_hunger;
	Need m_thirst;

	[SerializeField]
	[Range(0, 10)]
	float m_fHungerRate;

	[SerializeField]
	[Range(0, 10)]
	float m_fThirstRate;


	[SerializeField]
	[Range(0, 10)]
	float m_fSpeed;

	Inventory m_Inventory;


	//////////// Accessors ////////////////////////////////
	public Need GetThirst()
	{
		return m_thirst;
	}

	public Need GetHunger()
	{
		return m_hunger;
	}

	public Inventory GetInventory()
	{
		return m_Inventory;
	}


	// Use this for initialization
	void Start()
	{
		m_hunger = new Need(40, 5, 80, 50, 20);
		m_thirst = new Need(40, 5, 80, 50, 20);

		m_BaseGoal = new GoalSurvive(this);
		m_Inventory = new Inventory();
		m_Inventory.AddItem(new Resource(Resource.EType.food, 10));
	}

	// Update is called once per frame
	void Update()
	{
		DebugPrint();

		if (m_BaseGoal != null)
		{
			m_BaseGoal.Update();
		}

		m_hunger.Modify(Time.deltaTime * UnityEngine.Random.value * m_fHungerRate);
		m_thirst.Modify(Time.deltaTime * UnityEngine.Random.value * m_fThirstRate);
	}

	void DebugPrint()
	{
		DebugText.Print("Hunger : " + GetHunger().Get());
		DebugText.Print("Thirst : " + GetThirst().Get());
	}


	public void MoveTowardsTarget(Transform target)
	{
		transform.LookAt(target);
		transform.Translate(transform.forward * Time.deltaTime * m_fSpeed , Space.World);
	}

	public bool IsNearTarget(Transform target, float range)
	{
		float dist = Vector3.Distance(target.position, transform.position);
		if(dist < range)
		{
			return true;
		}
		return false;
	}

}
