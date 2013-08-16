using UnityEngine;
using System.Collections;

public class BossTrigger : MonoBehaviour
{
	public GameObject quillsMaster;
	
	void OnTriggerExit(Collider c)
	{
		if(c.name=="Player")
		{
			quillsMaster.SetActive(true);
			collider.enabled = false;
			Destroy(gameObject);
		}
	}
}
