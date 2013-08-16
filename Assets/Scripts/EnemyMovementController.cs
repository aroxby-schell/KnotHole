using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour
{
	private const float personalSpace = 1f;
	private const float sightRange = 2f;
	private const float moveSpeed = 1.25f;
	
	public Transform target;
	public Transform eyePos;
	public GameObject ignoreLayer;
	
	//Debugging
	public bool canSee = false;

	private int layerMask;
	
	void Start()
	{
		layerMask = ~(1<<ignoreLayer.layer);
	}
	
	void Update()
	{
		rigidbody.velocity = Vector3.zero;
		
		if(target && CanSeeTarget())
		{
			Vector3 dist = target.position - transform.position;
			
			if(dist.magnitude>personalSpace)
			{			
				Vector3 goal = target.position - dist.normalized*personalSpace;
				Vector3 dir = goal - transform.position;
				dir.y = 0f;
				if(!Utils.IsZeroVector(dir))
				{
					dir.Normalize();
					transform.forward = dir;
					rigidbody.velocity = dir * moveSpeed;
				}
			}
		}
	}
	
	private bool CanSeeTarget()
	{
		RaycastHit hitInfo;
		Vector3 dir = target.position - eyePos.position;
		float radius = transform.lossyScale.x;
		
		bool hit = Physics.SphereCast(eyePos.position, radius, dir, out hitInfo, sightRange, layerMask);

		canSee = hit && hitInfo.transform.tag == target.tag;
		return canSee;
	}
}
