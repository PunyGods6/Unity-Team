using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDataBase : MonoBehaviour
{

    //will have functions to get data about tasks

    //temp
    public static GameObject cafeEntrance;


    public static TaskData GetDataOfTaskFromDataBase(string taskName_)
	{
        //look up task name line

        //return in format of taskdata
        TaskData v = new TaskData();

        v.name = "TakeBoxHere";
        v.taskType = Task.TaskType.PlaceItem;
        v.taskDescription = "move box to location";
        v.tasksMainObject_Name = "BoxObject";
        v.tasksObj_ToInteractWith = cafeEntrance;
        v.taskCompleteCondition = Task.TaskCompleteCondition.Proximity_Sphere;
        v.detectorRadius = 8f;


        return v;
	}


}





