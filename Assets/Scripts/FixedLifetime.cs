using UnityEngine;
using System.Collections;

public class FixedLifetime : MonoBehaviour
{
	private float deathTime;
	private bool setup = false;
	
	public void SetTime(float time)
	{
		deathTime = Time.timeSinceLevelLoad + time;
		setup = true;
		enabled = true;
	}
	
	void Update()
	{
		if(setup && Time.timeSinceLevelLoad>=deathTime)
		{
			setup = false;
			Destroy(gameObject);
			gameObject.SetActive(false);
		}
	}
}
