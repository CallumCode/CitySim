using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSurvive : Goal
{
	public GoalSurvive(Agent owner) : base(owner)
	{
		m_sName = "Survive";
	}

	protected override Goal ChooseSubGoal()
	{
		if (m_agent.GetHunger().IsHigh())
		{
			return new GoalEat(m_agent);
		}

		if (m_agent.GetThirst().IsHigh())
		{
			return new GoalDrink(m_agent);
		}

		return null;
	}


	protected override void DropSubGoalCheck()
	{
		// ok this should not be hadcoded think on it
		if (m_agent.GetHunger().IsDangerousHigh())
		{
			if(m_subGoal.GetName() == "Drink"  )
			{
				m_subGoal.Drop();
				m_subGoal = new GoalEat(m_agent);
			}
		}


		if (m_agent.GetThirst().IsDangerousHigh())
		{

			if (m_subGoal.GetName() == "Eat")
			{
				m_subGoal.Drop();
				m_subGoal = new GoalDrink(m_agent);
			}
		}

	}


}
