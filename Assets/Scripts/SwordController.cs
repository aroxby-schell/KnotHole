using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordController : MonoBehaviour
{
	private Vector3 swordRest;
	private Vector3 swordAttack;
	private Vector3 swordGoal;
	
	//FIXME: These should be variable from instance to instance
	private const float swordSpeed = 5f;
	private Vector3 swordDest = new Vector3(0f, 0.25f, 0.75f);
	
	private bool attacking = false;
	public bool isAttacking { get { return attacking; } }
	
	private List<DamageController> hitList = new List<DamageController>();
	
	void Start()
	{		
		swordGoal = swordRest = transform.localPosition;
		swordAttack = swordDest;
	}
	
	void Update()
	{
		//nonthing to do
		if(!attacking) return;
		
		Vector3 swordPos = transform.localPosition;
		if(MoveTowards(ref swordPos, swordGoal, swordSpeed * Time.deltaTime))
		{
			if(swordGoal == swordRest)
			{				
				attacking = false;
			}
			else swordGoal = swordRest;
			
		}
		transform.localPosition = swordPos;
	}
	
	public void Attack()
	{
		swordGoal = swordAttack;
		hitList.Clear();
		attacking = true;
	}
	
	public bool SetHit(DamageController dmg)
	{
		bool haveIt = hitList.Contains(dmg);
		if(!haveIt) hitList.Add(dmg);
		return haveIt;
	}
	
	private bool MoveTowards(ref Vector3 pos, Vector3 goal, float maxDist)
	{
		Vector3 totalDist = goal - pos;
		if(Utils.IsZeroVector(totalDist)) return true;
		Vector3 stepDist = totalDist.normalized * maxDist;
		Vector3 movement = stepDist.sqrMagnitude<totalDist.sqrMagnitude?stepDist:totalDist;
		pos += movement;
		return false;
	}
}
