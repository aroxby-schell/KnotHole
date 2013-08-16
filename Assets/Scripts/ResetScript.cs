using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour
{
	void OnButtonClicked(object o)
	{
		Application.LoadLevel( Application.loadedLevel );
	}
}
