using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
	ArrayList m_Contents = new ArrayList();
	
	public void AddItem(Resource resource)
	{
		m_Contents.Add(resource);
	}


	public Resource FindOfType( Resource.EType type)
	{
		int index = 0;
		foreach(Resource item in m_Contents)
		{
			if(item.GetResourceType() == type)
			{
				return item;
			}

			index++;
		}

		return null;
	}


	public void RemoveByIndex(int index)
	{
		if( index < m_Contents.Count && index > 0)
		{
			m_Contents.RemoveAt(index);
		}
	}

	public void RemoveReasource(Resource item )
	{
		m_Contents.Remove(item);
	}
}
