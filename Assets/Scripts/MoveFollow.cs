using UnityEngine;
using System.Collections;

public class MoveFollow : MonoBehaviour
{
	public Transform target;
	private Vector3 offset;
	
	void Start()
	{
		offset = transform.position - target.position;
	}

	void Update()
	{
		if(target) transform.position = target.position + offset;
	}
}
