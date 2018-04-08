 
public class Need
{
	float m_fValue = 0;
	int m_iPriority = 1;
	float m_fDangerValue = 0;
	float m_fHighValue = 0;
	float m_fLowValue = 0;

	public Need(float inital, int priority, float danger, float high, float low)
	{
		m_fValue = inital;
		m_iPriority = priority;
		m_fDangerValue = danger;
		m_fHighValue = high;
		m_fLowValue = low;
	}

	public float Get()
	{
		return m_fValue;
	}

	public void Modify(float delta)
	{
		m_fValue += delta;
	}
	
	public bool IsDangerousHigh()
	{
		return m_fValue >= m_fDangerValue;
	}

	public bool IsHigh()
	{
		return m_fValue >= m_fHighValue; 
	}

	public bool IsLow()
	{
		return m_fValue <= m_fLowValue; 
	}
}
