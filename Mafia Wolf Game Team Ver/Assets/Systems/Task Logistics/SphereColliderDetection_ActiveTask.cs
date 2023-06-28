using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderDetection_ActiveTask : MonoBehaviour
{

    public ActiveTask activeTaskScript;
	public string gameObject_Name;


	private void OnTriggerEnter(Collider info)
	{
		if (info.gameObject.name.ToString() == gameObject_Name)
		{
			//activeTaskScript.CompleteTask();
		}
		
	}



}
