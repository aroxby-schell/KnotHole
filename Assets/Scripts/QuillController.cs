using UnityEngine;
using System.Collections;

public class QuillController : MonoBehaviour
{
	private const float atkDelay = 0.25f;
	private const float quillSpeed = 8f;
	private const float quillLife = 2f;
	
	private const float volleyDelay = 1.5f;
	private const int volleyCount = 3;
	
	private float nextAtkTime = 0f;
	private int countThrown = 0;
	
	//public float timingOffset = 0f;
	public bool waitOneVolleyDelay = false;
	public GameObject[] quills;
	
	void Start()
	{
		if(waitOneVolleyDelay) nextAtkTime = Time.timeSinceLevelLoad + volleyCount * atkDelay;
	}
	
	void Update()
	{
		if(Time.timeSinceLevelLoad>=nextAtkTime)
		{
			Attack();
			
			countThrown++;
			if(countThrown>=volleyCount)
			{
				countThrown = 0;
				nextAtkTime = Time.timeSinceLevelLoad + volleyDelay;
			}
			else nextAtkTime = Time.timeSinceLevelLoad + atkDelay;
		}
	}
	
	public void StartAttack()
	{
		nextAtkTime = Time.timeSinceLevelLoad;
	}
	
	private void Attack()
	{
		Attack(Utils.randomElem(quills));
	}
	
	private void Attack(GameObject quill)
	{
		GameObject newQuill = (GameObject)Instantiate(quill, quill.transform.position, quill.transform.rotation);
		newQuill.rigidbody.velocity = newQuill.transform.forward * quillSpeed;
		newQuill.GetComponent<FixedLifetime>().SetTime(quillLife);
	}
}
