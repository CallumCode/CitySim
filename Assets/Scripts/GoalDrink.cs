using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDrink : Goal
{
	public GoalDrink(Agent owner) : base(owner)
	{
		m_sName = "Drink";
	}

	protected override void UpdateNoSubGoal()
	{

		m_agent.GetThirst().Modify(-Time.deltaTime * 20.0f);
	}

	protected override bool IsFinished()
	{
		if (m_agent.GetThirst().IsLow() )
		{
			return true;
		}
		
		return false;
	}
}