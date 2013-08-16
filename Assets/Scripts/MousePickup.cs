using UnityEngine;
using System.Collections;

public class MousePickup : MonoBehaviour
{
	public Transform player;
	public GameObject pickupLayer;
	
	private bool dispItem; //if your mouse is over an item -- disp what item
	private string item; //name of the item on the ground
	
	private int layerMask;

	// Use this for initialization
	void Start()
	{
		dispItem = false;
		item = "";
		layerMask = 1<<pickupLayer.layer;
	}
	
	// Update is called once per frame
	void Update()
	{
		Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);  //A ray from the camera to where your mouse is on the screen
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 10f, layerMask) && CloseToPlayer(hit.point))
		{
				dispItem = true;
				item = hit.collider.tag;
		}
		else dispItem = false;
		
		if(dispItem && Input.GetMouseButtonDown(0))
		{
				hit.collider.gameObject.SendMessage("OnPickup");
		}
	}
	
	private bool CloseToPlayer(Vector3 pt)
	{
		return (player.position-pt).sqrMagnitude<=2f;
	}
	
	void OnGUI()
	{
		//Mouse over sword, disp sword in corner
		if(dispItem)
		{
			GUI.Box(new Rect(3*Screen.width/4, 3*Screen.height/4, 150,30), item);
		}
	}
}