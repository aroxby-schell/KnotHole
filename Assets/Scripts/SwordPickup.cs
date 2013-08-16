using UnityEngine;
using System.Collections;

public class SwordPickup : MonoBehaviour
{
	public GameObject playerSword;
	
	void OnPickup()
	{
		playerSword.SetActive(true);
		Destroy(transform.parent.gameObject);
	}
	
	/* Disabled to encourage player to use mouse
	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.name=="Player") OnPickup();
	}
	*/
}
