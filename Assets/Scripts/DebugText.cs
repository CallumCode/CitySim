using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugText : MonoBehaviour
{
	private static DebugText ms_Instance = null;

	private Queue<string> m_PendingStrings = new Queue<string>();
	private Queue<string> m_ActiveStrings = new Queue<string>();

	[SerializeField]
	private Rect m_ScreenPosition = new Rect();

	// Unity Methods

	void Start()
	{
		Debug.Assert(ms_Instance == null);
		ms_Instance = this;
	}

	void LateUpdate()
	{
		// Clear the active queue, and move the pending queue over
		m_ActiveStrings.Clear();
		Queue<string> swapQueue = m_ActiveStrings;
		m_ActiveStrings = m_PendingStrings;
		m_PendingStrings = swapQueue;
	}

	void OnGUI()
	{
		Rect position = m_ScreenPosition;
		GUIStyle style = GUI.skin.label;
		foreach (string str in m_ActiveStrings)
		{
			GUIContent content = new GUIContent(str);
			GUI.Label(position, content, style);
			position.y += style.CalcSize(content).y;
		}
	}

	// DebugText API

	private void PrintInternal(string str)
	{
		m_PendingStrings.Enqueue(str);
	}

	// DebugText Static API

	/// <summary>
	/// Output the specified string to the DebugText area
	/// </summary>
	/// <param name="str">String to output</param>
	public static void Print(string str)
	{
		ms_Instance.PrintInternal(str);
	}
}
