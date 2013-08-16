using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour
{
	public GameObject senseThis;
	
	private bool inTrigger = false;	
	public bool hot { get { return inTrigger; } }

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject==senseThis) inTrigger = true;
	}
	
	void OnTriggerExit(Collider c)
	{
		if(c.gameObject==senseThis) inTrigger = false;
	}
}
