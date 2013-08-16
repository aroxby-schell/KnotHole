using UnityEngine;
using System.Collections;

public class EnemyCombatController : MonoBehaviour
{
	private const float attackDelay = 0.5f;
	private float nextAttack = 0f;
	
	public SwordController sword;
	public Sensor playerSensor;
	
	void Update()
	{
		if(playerSensor.hot && Time.timeSinceLevelLoad>=nextAttack && !sword.isAttacking)
		{
			sword.Attack();
			nextAttack = Time.timeSinceLevelLoad + attackDelay;
		}
	}
}
