using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEat : Goal
{

	public GoalEat(Agent owner) : base(owner)
	{
		m_sName = "Eat";
	}

	protected override void UpdateNoSubGoal()
	{

		m_agent.GetHunger().Modify(-Time.deltaTime * 1.0f);
	}

	protected override bool IsFinished()
	{
		if (m_agent.GetHunger().IsLow())
		{
			return true;
		}
		return false;
	}
	
}
