using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGoSomeWhere : Goal
{

	GameObject m_target;

	float m_fNearRange = 1;
	float m_fMaxRange = 100;

	public GoalGoSomeWhere(Agent owner) : base (owner)
	{
		m_sName = "GoSomeWhere";


		//move this out so children call there own
		m_target  = new GameObject(m_agent.name + m_sName);
		FindNewLocation();
	}

	void FindNewLocation()
	{				Vector3 position = new Vector3(Random.Range(-m_fMaxRange, m_fMaxRange), 0, Random.Range(-m_fMaxRange, m_fMaxRange));
		m_target.transform.position = position;
	}


	protected override void UpdateNoSubGoal()
	{
		m_agent.MoveTowardsTarget(m_target.transform);

		if(m_agent.IsNearTarget(m_target.transform , m_fNearRange))
		{
			FindNewLocation();
		}

	}


	public override void Drop()
	{
		base.Drop();

		Object.Destroy(m_target);
	}

}
