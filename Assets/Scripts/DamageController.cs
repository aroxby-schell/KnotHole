using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour
{
	public int hp = 4;
	public GameObject enemyTag;
	public TextMesh hpText;
	public bool keepDeathHP = false;
	
	private string enemy;
	
	void Start()
	{
		enemy = enemyTag.tag;
		UpdateString();
	}
	
	void OnTriggerEnter(Collider c)
	{
		CheckCollider(c, false);
	}
	
	void OnTriggerStay(Collider c)
	{
		CheckCollider(c, true);
	}
	
	private void CheckCollider(Collider c, bool isStay)
	{		
		if(c.tag==enemy)
		{			
			SwordController sword = c.GetComponent<SwordController>();
			if(sword)
			{
				if(sword.isAttacking && !sword.SetHit(this)) TakeDamage(2);
			}
			else if(!isStay)	//Only sword attacks are valid for OnTriggerStay 
			{
				TakeDamage(2);
			}
		}
	}
	
	public void TakeDamage(int dmg)
	{
		hp-= dmg;
		if(hp<=0)
		{
			hp = 0;
			Die();
		}
		UpdateString();
	}
	
	private void UpdateString()
	{
		if(hpText) hpText.text = "HP: " + hp.ToString("D2");
	}
	
	private void Die()
	{
		if(!keepDeathHP)
		{
			Destroy(hpText.gameObject);
			hpText.gameObject.SetActive(false);
		}
		
		Destroy(gameObject);
		gameObject.SetActive(false);
	}
}
