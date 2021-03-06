﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIMU_Controller : MonoBehaviour {

    // Use this for initialization\
    [SerializeField] float speed = 10;
    [SerializeField] public static bool canMove = true;
    
    public Transform currentInteractTarget;
    public int MAX_AMM0 = 1;
    public int ammo;

    public Vector3 startingPos;

	void Start () {
        ammo = 0;
        startingPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (canMove) {

            ProcessMovementInput();
            //GetInteractTarget();
            ProcessButtonInput();
        }
        Debug.Log(canMove);
        
	}



    private void ProcessButtonInput()
    {
        if(currentInteractTarget != null && Input.GetButtonDown("Fire1") && currentInteractTarget.GetComponent<IInteractable>() != null)
        {
            currentInteractTarget.GetComponent<IInteractable>().interact();
        }
    }

    private void ProcessMovementInput()
    {
        //print("moving");
        float VInput = Input.GetAxis("Vertical") * speed;
        float HInput = Input.GetAxis("Horizontal") * speed;
        Vector3 MoveVector = new Vector3(HInput, 0, VInput);
        MoveVector = Vector3.ClampMagnitude(MoveVector, speed);
        if (VInput != 0 || HInput != 0)
        {
            this.transform.rotation = Quaternion.LookRotation(MoveVector);
        }
        else if(GetComponent<Rigidbody>().velocity.y > 0)
        {
            GetComponent<Rigidbody>().velocity = Vector3.Scale(GetComponent<Rigidbody>().velocity, new Vector3(1, 0, 1));
        }
        GetComponent<Rigidbody>().velocity = MoveVector + Vector3.Scale(GetComponent<Rigidbody>().velocity, (new Vector3(0, 1, 0)));
    }
}
