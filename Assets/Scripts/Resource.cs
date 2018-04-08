using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
	public Resource(EType type , float amount)
	{
		m_type = type;
		m_fAmount = amount;
	}

	float m_fAmount;
	//float m_fWeight;
	//float m_fVolume;

	public enum EType
	{
		food,
		drink,
	}

	EType m_type; 
	
	public float GetAmount()
	{
		return m_fAmount;
	}

	public EType GetResourceType()
	{
		return m_type;
	}
}
