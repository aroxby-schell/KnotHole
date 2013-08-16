using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public SwordController sword;
	
	private const float moveVelScale = 2f;
	
	void Update()
	{
		UpdateMovement();
		UpdateSword();
		
		if(Input.GetKeyDown(KeyCode.Keypad0)) GetComponent<DamageController>().TakeDamage(-50);
	}
	
	private void UpdateMovement()
	{
		Vector3 velocity = Vector3.zero;
		
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow   ) ) velocity += Vector3.forward;
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow ) ) velocity += Vector3.left;
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow ) ) velocity += Vector3.back;
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ) velocity += Vector3.right;
		
		rigidbody.velocity = velocity * moveVelScale;
		//Should this be normalized first?
		if(!Utils.IsZeroVector(velocity)) transform.forward = velocity;
	}
	
	private void UpdateSword()
	{
		if(Input.GetKeyDown(KeyCode.Space)) sword.Attack();
	}
}
