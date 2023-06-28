using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskData : MonoBehaviour
{

    public string taskName;
    public Task.TaskType taskType;
    public string taskDescription;

    public string tasksMainObject_Name;
    public GameObject tasksObj_ToInteractWith;
    public Vector3 tasksObj_ToInteractWith_PositionOffset;


    public Task.TaskCompleteCondition taskCompleteCondition;
    public float detectorRadius;


}
