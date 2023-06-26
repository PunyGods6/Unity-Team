using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTask : MonoBehaviour
{

	//script manages an ActiveTask 


	//types of tasks
	public enum TaskType { PlaceItem, GoHere, Interact, Aquire }
	//tasks name and infomation that can be called
	private string taskName;
	private string taskDescription;
	private TaskType taskType;
	public GameObject gameObjectToPlaceDetectorsUnder;      //palce to spawn detector colliders , so they dont move with this object- have empty in world to spawn detectors under
	public GameObject sphearColliderObjExample;

	public void StartTask()
	{
		Debug.Log("StartTask");
	}

	public void CompleteTask()
	{
		Debug.Log("TaskCompleted");
	}

}


public class PlaceItemTask : ActiveTask
{
	private GameObject itemToPlace;
	private Vector3 worldPositionToPlace;
	private float radiusOfDetector;
	private GameObject sphereDetector;

	private void StartTask_PlaceItemTask()
	{
		//add sphear collider component to this
		sphereDetector = Instantiate(sphearColliderObjExample, worldPositionToPlace, Quaternion.identity, gameObjectToPlaceDetectorsUnder.transform);
		// Customize the properties of the added component
		sphereDetector.GetComponent<SphereCollider>().radius = radiusOfDetector;

		StartTask();
	}
	private void CompleteTask_PlaceItemTask()
	{
		Destroy(sphereDetector);
		CompleteTask();
	}


	private void Update()
	{
		//if()
	}
}
