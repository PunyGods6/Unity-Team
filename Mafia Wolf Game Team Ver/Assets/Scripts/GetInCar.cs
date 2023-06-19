using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcadeVP;

public class GetInCar : MonoBehaviour
{
    [SerializeField] private ArcadeVehicleController carPhysics;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject car;
    [SerializeField] private AudioSource engine;
    [SerializeField] private AudioSource skid;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject carCamera;

    [SerializeField] private PlayerPickUpDrop pickUpDropScript;

    [SerializeField] private float interactionDistance = 3f;

    private float carStartUpTimer = -1;
    private bool carStartUpOn = false;
    public float startUpTimer = 2;

    public bool isPlayerInCar = false;

    private void Start()
    {
        carPhysics.enabled = false;
        engine.enabled = false;
        skid.enabled = false;

        // Disable the car's Rigidbody
        //Rigidbody carRigidbody = car.GetComponentInChildren<Rigidbody>();
        //carRigidbody.isKinematic = true;

        // Enable the main camera
        mainCamera.SetActive(true);

        // Disable the car camera
        carCamera.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPlayerInCar)
            {
                ExitCar();
            }
            else
            {
                TryEnterCar();
            }
        }

		if (carStartUpOn)
		{
            carStartUpTimer -= Time.deltaTime;
            Debug.Log("Car Starting" + carStartUpTimer);

			if (carStartUpTimer <= 0)
			{
                carStartUpOn = false;

                // Enable car controls
                carPhysics.enabled = true;
                engine.enabled = true;
                skid.enabled = true;
            }
		}
    }

    private void TryEnterCar()
    {
        float distance = Vector3.Distance(player.transform.position, car.transform.position);

        if (distance <= interactionDistance)
        {
			if (pickUpDropScript.IsObjectInHand() == true)
			{
                pickUpDropScript.DropObject();
            }
            EnterCar();
        }
    }

    private void EnterCar()
    {
        carStartUpTimer = startUpTimer;

        carStartUpOn = true;

        // Disable player character controller
        player.GetComponent<CharacterController>().enabled = false;

        // Set the car as the parent of the player to make them move together
        player.transform.parent = car.transform;

        // Position the player inside the car
        player.transform.localPosition = Vector3.zero;

        // Disable the main camera
        mainCamera.SetActive(false);

        // Enable the car camera
        carCamera.SetActive(true);

        // Disable player controls
        player.SetActive(false);

        isPlayerInCar = true;

        // Enable the car's Rigidbody
        //Rigidbody carRigidbody = car.GetComponentInChildren<Rigidbody>();
        //carRigidbody.isKinematic = false;
    }

    private void ExitCar()
    {
        // Disable car controls
        carPhysics.enabled = false;
        engine.enabled = false;
        skid.enabled = false;
        
        // Move the player to the right side of the car
        player.transform.position = car.transform.position + (car.transform.right * 2f);
        
        // Enable player controls
        player.SetActive(true);

        // Enable player character controller
        player.GetComponent<CharacterController>().enabled = true;

        // Remove the car as the parent of the player
        player.transform.parent = null;

        isPlayerInCar = false;

        // Disable the car's Rigidbody
        //Rigidbody carRigidbody = car.GetComponentInChildren<Rigidbody>();
        //carRigidbody.isKinematic = true;

        // Enable the main camera
        mainCamera.SetActive(true);

        // Disable the car camera
        carCamera.SetActive(false);
    }
}
