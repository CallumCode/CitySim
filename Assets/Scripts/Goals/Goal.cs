using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


public class Goal
{
 	protected Goal m_subGoal;
	protected Agent m_agent;

	protected String m_sName;

	////////////////////////////////// public functions

	public Goal(Agent owner)
	{
		m_agent = owner;
		m_subGoal = null;
		m_sName = "BaseGoal";
	}

	/// <summary>
	/// This is called by its parent Goal or agent
	/// </summary>
	public void Update()
	{
		DebugText.Print("Goal: " +m_sName);
		if (m_subGoal == null)
		{
			UpdateActive();
		}
		else
		{
			m_subGoal.Update();

			if (m_subGoal.IsFinished() )
			{
				m_subGoal.Drop();
				m_subGoal = null;
			}
			UpdateWithSubGoal();
		}
	}

	public String GetName()
	{
		return m_sName;
	}

	/////////////////////////////////////  virtual protected functions

	/// <summary>
	/// Update fucntion when we have no sub goal. 
	/// Which means we should either find a subgoal or be able to solve reach our goal
	/// </summary>
	virtual protected void UpdateActive()
	{
		m_subGoal	= ChooseSubGoal();

		if(m_subGoal == null)
		{
			UpdateNoSubGoal();
		}

	}

	/// <summary>
	/// Update when we have a sub goal. This is mainly to decide if we should drop sub goal 
	/// </summary>
	virtual protected void UpdateWithSubGoal()
	{
		DropSubGoalCheck();
	}

	/// <summary>
	/// This checks if we should drop sub goal ie other requirments are more imporant 
	/// </summary>
	virtual protected void DropSubGoalCheck()
	{

	}

	/// <summary>
	/// Decide what subgoal if we need a sub goal , ie eat: find food
	/// </summary>
	/// 
	virtual protected  Goal ChooseSubGoal()
	{
		return null;
	}

	/// <summary>
	/// so if we have no subgoal we should be able to just what we want without doing anything else
	/// Some sort of idle and sucess is needed
	/// </summary>
	/// 
	virtual protected void UpdateNoSubGoal()
	{

	}

	/// <summary>
	/// this is so we check if we have completed a goal
	///
	virtual protected bool IsFinished()
	{
		return false;
	}

	/// <summary>
	/// Shutdown whaterver wee are  doing 
	/// And drop all sub goals
	///
	virtual public void Drop()
	{
		if(m_subGoal != null)
		{
			m_subGoal.Drop();
			m_subGoal = null;
		}

	}


}


