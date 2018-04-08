using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEat : Goal
{
	float m_fFoodHeld = 0;


	public GoalEat(Agent owner) : base(owner)
	{
		m_sName = "Eat";
	}

	protected override void UpdateNoSubGoal()
	{

		if (m_fFoodHeld > 0)
		{
			float eatRate = Time.deltaTime * 1.0f;
			float newFoodValue = Mathf.Max((m_fFoodHeld - eatRate), 0.0f);
			float foodToEat = (newFoodValue - m_fFoodHeld);
			m_agent.GetHunger().Modify(foodToEat);

			m_fFoodHeld = newFoodValue;
		}
	

	}

	protected override bool IsFinished()
	{
		if (m_agent.GetHunger().IsLow())
		{
			return true;
		}
		return false;
	}

	protected override Goal ChooseSubGoal()
	{

		if (m_fFoodHeld > 0)
		{
			// we have food so eat it 
			return null;
		}
		else 
		{
			Resource aFood = m_agent.GetInventory().FindOfType(Resource.EType.food);
			if (aFood != null)
			{
				m_fFoodHeld = aFood.GetAmount();
				m_agent.GetInventory().RemoveReasource(aFood);
				return null;
			}

			// ok we need go food ... will do something like knowalge of locations at some poitn

			return new GoalGoGetFood(m_agent);
		}	
	}

	


}
