using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : TriggerInteractable, IInteractable {

    enum MoveState {resting, movingdown, movingup, finished };

    MoveState state;
    //[SerializeField] Transform PLAYER;
    [SerializeField] Vector3 positionalOffset;
    [SerializeField] float speed = 5;
    [SerializeField] float shakeTime;
    [SerializeField] Vector3 runeoffset;
    //[SerializeField] Transform orbRef;
    Vector3 targetPosition;
    Vector3 startPosition;
    Transform child;
	// Use this for initialization

	void Start () {
        targetPosition = transform.position + positionalOffset;
        state = MoveState.resting;
        requiresPower = true;
        startPosition = transform.position;
        child = transform.GetChild(0);
    }
	
	// Update is called once per frame
	void Update () {

		if(state == MoveState.movingdown)
        {
            Debug.Log("really should b moving");
            child.position = Vector3.MoveTowards(child.position, targetPosition, speed * Time.deltaTime);
            
            if(child.position == targetPosition)
            {
                Debug.Log("Move Complete");
                state = MoveState.finished;
                //GetComponent<SphereCollider>().enabled = false;
                GetComponent<CameraShake>().enabled = false;
                DIMU_Controller.canMove = true;
            }
        }
        else if (state == MoveState.movingup)
        {

            child.position = Vector3.MoveTowards(child.position, startPosition, speed * Time.deltaTime);
            DIMU_Controller.canMove = false;
            if (child.position == startPosition)
            {
                Debug.Log("Move Complete");
                state = MoveState.resting;
                //GetComponent<SphereCollider>().enabled = false;
                GetComponent<CameraShake>().enabled = false;
                DIMU_Controller.canMove = true;
            }
        }
	}

    public void interact()
    {
        if(state == MoveState.resting && PLAYER.GetComponent<DIMU_Controller>().ammo > 0)
        {
            spawnRune(runeoffset);
            state = MoveState.movingdown;
            Debug.Log("MOVING");

            GetComponent<CameraShake>().enabled = true;
            DIMU_Controller.canMove = false;

            SpendAmmo(-1, false);
        }
        else if (state == MoveState.finished && PLAYER.GetComponent<DIMU_Controller>().ammo < PLAYER.GetComponent<DIMU_Controller>().MAX_AMM0)
        {
            state = MoveState.movingup;
            Debug.Log("MOVING");

            GetComponent<CameraShake>().enabled = true;
            DIMU_Controller.canMove = false;
            SpendAmmo(1, true);
            despawnRune();
        }
    }
    /*
    void OnTriggerEnter(Collider other)
    {
        PLAYER.GetComponent<DIMU_Controller>().currentInteractTarget = transform;
    }

    void OnTriggerExit(Collider other)
    {
        PLAYER.GetComponent<DIMU_Controller>().currentInteractTarget = null;
    }
    */
}
