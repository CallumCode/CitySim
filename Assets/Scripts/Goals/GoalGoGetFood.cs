using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGoGetFood : GoalGoSomeWhere
{
	public GoalGoGetFood(Agent owner) : base(owner)
	{
		m_sName = "GoGetFood";
	}
}
