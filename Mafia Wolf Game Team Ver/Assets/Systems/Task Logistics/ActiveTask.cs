using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActiveTask : MonoBehaviour
{

	private void Awake()
	{
		//CreateTask(Task.TaskType.PlaceItem, "TestTask1");
	}


	//public Task CreateTask(TaskData data_)
	//{
	//	Task taskCreated;
	//
	//	switch (data_.taskType)
	//	{
	//		case Task.TaskType.PlaceItem:
	//			taskCreated = new PlaceItemTask();
	//			//taskCreated.StartTask();
	//			
	//			
	//
	//			
	//
	//			
	//		case Task.TaskType.GoHere:
	//			return null;
	//		case Task.TaskType.Interact:
	//			return null;
	//		case Task.TaskType.Aquire:
	//			return null;
	//		default:
	//			return null;
	//	}
	//
	//
	//	taskCreated.taskType = data_.taskType;
	//	taskCreated.taskName = name_;
	//
	//
	//	return taskCreated;
	//
	//}

}







public class Task : MonoBehaviour
{

	//script manages an ActiveTask 


	//types of tasks
	public enum TaskType { PlaceItem, GoHere, Interact, Aquire }
	public enum TaskCompleteCondition { Proximity_Sphere, OnContact }


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
	//when task is done, call this tasks name to be removed from managers active task list
	TaskManager thisTasksManager;

	//customizable per task
	public string mainObject;
	public GameObject placeRelativeToObj;
	public Vector3 placeRelativeToObj_PositionOffset;
	public float radiusOfDetector;

	//grabbed from catalogue
	public GameObject sphearColliderObjExampleToClone;

	//created to keep track of temp component so it can be delete later	
	public List<GameObject> tempSpawnedObjs = new List<GameObject>();


	//script already under the object it should be,
	public void StartTask(TaskManager thisTasksManager_, TaskData d, GameObject sphereDetectorToClone_)
	{

		//so it can report back to once this task is done
		thisTasksManager = thisTasksManager_;

		mainObject = d.tasksMainObject_Name;
		placeRelativeToObj = d.tasksObj_ToInteractWith;
		placeRelativeToObj_PositionOffset = d.tasksObj_ToInteractWith_PositionOffset;
		radiusOfDetector = d.detectorRadius;
		sphearColliderObjExampleToClone = sphereDetectorToClone_;




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
