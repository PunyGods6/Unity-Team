using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    //testing
    //manage - spawn/despawn tasks

    public GameObject playerObj;


    //datasets?
    TaskData testData = TaskDataBase.GetDataOfTaskFromDataBase("testing_name");
    public GameObject taskTools_SphereDetector;


    // including the derived classes that inherit from the TaskBase class, you can make use of polymorphism
    private List<Task> activeTasks = new List<Task>();



	private void Start()
	{
        SpawnTask(testData, playerObj);
	}

	// Method to spawn a new task and add it to the active task list
	public void SpawnTask(TaskData taskData_, GameObject whosTask_)
    {

        //spawn task - under relavent player
        whosTask_.AddComponent<PlaceItemTask>();
        //whosTask_.AddComponent<PlaceItemTask>().StartTask(taskData_.tasksMainObject_Name, taskData_.tasksObj_ToInteractWith, taskData_.);


        //activeTasks.Add( player.GetComponent<ActiveTask>().CreateTask(Task.TaskType.PlaceItem, "TestTaskName100"));
    }

    // Method to remove a completed task from the active task list
    public void RemoveCompletedTask(Task task_)
    {
        activeTasks.Remove(task_);
    }



}
