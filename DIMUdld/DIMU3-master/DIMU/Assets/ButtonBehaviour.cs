using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : TriggerInteractable, IInteractable {

    enum MoveState {unpressed, moving, finished };
    MoveState state;

    [SerializeField] Transform BridgeTarget;
    [SerializeField] Vector3 StartingPosOffset;
    [SerializeField] float moveSpeed = 5;
    Vector3 startingPos;

    private Transform child;
	// Use this for initialization
	void Start () {

        state = MoveState.unpressed;
        startingPos = BridgeTarget.position;
        BridgeTarget.position = startingPos + StartingPosOffset;
        child = transform.GetChild(0);
        child.GetComponent<Renderer>().material.SetColor("Emission", Color.red);
    }
	
	// Update is called once per frame
	void Update () {
		
        if(state == MoveState.moving)
        {
            BridgeTarget.transform.position = Vector3.MoveTowards(BridgeTarget.position, startingPos, moveSpeed * Time.deltaTime);

            if(BridgeTarget.position == startingPos)
            {
                endMove();
            }
        }
	}

    private void endMove()
    {
        state = MoveState.finished;
        DIMU_Controller.canMove = true;
        BridgeTarget.GetComponent<Floater>().enabled = true;
        BridgeTarget.GetComponent<Floater>().posOffset = startingPos;
        GetComponent<CameraShake>().enabled = false;
    }

    public void interact()
    {
        if(state == MoveState.unpressed)
        {
            state = MoveState.moving;
            DIMU_Controller.canMove = false;
            BridgeTarget.GetComponent<Floater>().enabled = false;
            child.GetComponent<Renderer>().material.SetColor("Emission", Color.green);
            GetComponent<CameraShake>().enabled = true;
        }
    }
}
