using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActiveTask : MonoBehaviour
{

	private void Start()
	{
		CreateTask(Task.TaskType.PlaceItem, "TestTask1");
	}


	public void CreateTask(Task.TaskType taskType_, string name_)
	{
		switch (taskType_)
		{
			case Task.TaskType.PlaceItem:
				Task taskCreated = new PlaceItemTask();
				//taskCreated.StartTask();
				taskCreated.taskType = taskType_;
				taskCreated.taskName = name_;

				

				break;
			case Task.TaskType.GoHere:
				break;
			case Task.TaskType.Interact:
				break;
			case Task.TaskType.Aquire:
				break;
			default:
				break;
		}
	}

}







public class Task : MonoBehaviour
{

	//script manages an ActiveTask 


	//types of tasks
	public enum TaskType { PlaceItem, GoHere, Interact, Aquire }

	//tasks name and infomation that can be called
	public string taskName;
	public TaskType taskType;	


	public void StartTaskBase()
	{
		Debug.Log("StartTaskBase");
	}

	public void CompleteTaskBase()
	{
		Debug.Log("TaskCompletedBase");
	}


	public void DestroySpawnedObjects(List<GameObject> tempSpawnedObjs_)
	{
		for (int i = tempSpawnedObjs_.Count - 1; i >= 0; i--)
		{
			Destroy(tempSpawnedObjs_[i]);
			tempSpawnedObjs_.RemoveAt(i);
		}
	}
}


public class PlaceItemTask : Task
{
	public GameObject itemToPlace;
	public Vector3 worldPositionToPlace;
	public float radiusOfDetector;
	public GameObject sphereDetector;   //savingth eobject so it can be deleted when task complete

	public GameObject gameObjectToPlaceDetectorsUnder;      //palce to spawn detector colliders , so they dont move with this object- have empty in world to spawn detectors under
	public GameObject sphearColliderObjExample;

	public List<GameObject> tempSpawnedObjs = new List<GameObject>();

	public void StartTask(GameObject itemToPlace_, Vector3 worldPositionToPlace_, float radiusOfDetector, GameObject sphereDetector)
	{
		//add spawn sphear collider and adjust radius and position to where appropriate
		sphereDetector = Instantiate(sphearColliderObjExample, worldPositionToPlace, Quaternion.identity, gameObjectToPlaceDetectorsUnder.transform);
		// Customize the properties 
		sphereDetector.GetComponent<SphereCollider>().radius = radiusOfDetector;

		tempSpawnedObjs.Add(sphereDetector);
		StartTaskBase();
	}
	public void CompleteTask()
	{
		DestroySpawnedObjects(tempSpawnedObjs);
		CompleteTaskBase();
		Debug.Log("TaskCompleted");
	}

}
