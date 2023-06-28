using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    //testing
    //manage - spawn/despawn tasks
    public 
    
    // including the derived classes that inherit from the TaskBase class, you can make use of polymorphism
    private List<Task> activeTasks = new List<Task>();


	private void Start()
	{
        Debug.Log("started");
	}

	// Method to spawn a new task and add it to the active task list
	public void SpawnTask(Task task_)
    {
        activeTasks.Add(task_);
    }

    // Method to remove a completed task from the active task list
    public void RemoveCompletedTask(Task task_)
    {
        activeTasks.Remove(task_);
    }



}
