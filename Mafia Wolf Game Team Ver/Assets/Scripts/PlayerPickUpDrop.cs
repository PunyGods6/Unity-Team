using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
	[SerializeField] private Transform playerCameraTransform;
	[SerializeField] private Transform objectGrabPointTransform;
	[SerializeField] private LayerMask pickUpLayerMask;

	private ObjectGrabbable objectGrabbable;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (objectGrabbable == null)
			{
				//Not Carrying An Object, Try To Grab.
				PickUpObject();
			}
			else
			{
				//Currently Carrying Something, Drop It
				DropObject();
			}
		}
	}

	public bool IsObjectInHand()
	{
		if (objectGrabbable == null)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void DropObject()
	{
		//Currently Carrying Something, Drop It
		objectGrabbable.Drop();
		objectGrabbable = null;
	}

	public void PickUpObject()
	{
		//Not Carrying An Object, Try To Grab.
		float pickUpDistance = 2f;
		if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
		{
			if (raycastHit.transform.TryGetComponent(out objectGrabbable))
			{
				objectGrabbable.Grab(objectGrabPointTransform);
			}
		}
	}
}
