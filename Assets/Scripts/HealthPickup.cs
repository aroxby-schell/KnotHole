using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour
{
	public DamageController playerHealth;
	
	void OnPickup()
	{
		playerHealth.TakeDamage(-4);
		Destroy(transform.parent.gameObject);
	}
	
	/* Disabled to encourage player to use mouse
	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name=="Player") OnPickup();
	}
	*/
}
