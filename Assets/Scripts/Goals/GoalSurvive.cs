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
		
		return new GoalGoSomeWhere(m_agent);
	}


	protected override void DropSubGoalCheck()
	{
		// ok this should not be hadcoded think on it

		// one opntion is to pass in a copy of the needs/agent and compare the result 

		// Will also need to have a beter  priority system 


		if (m_agent.GetHunger().IsDangerousHigh())
		{
			if(m_subGoal.GetName() != "Eat")  // dont restart goal
			{
				m_subGoal.Drop();
				m_subGoal = new GoalEat(m_agent);
			}
		}


		if (m_agent.GetThirst().IsDangerousHigh())
		{

			if (m_subGoal.GetName() == "Drnk") // dont do what we are doing
			{
				m_subGoal.Drop();
				m_subGoal = new GoalDrink(m_agent);
			}
		}


	}


}
