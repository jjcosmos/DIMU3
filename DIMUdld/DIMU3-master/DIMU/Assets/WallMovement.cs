using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : TriggerInteractable, IInteractable {

    enum MoveState {resting, moving, finished };

    MoveState state;
    //[SerializeField] Transform PLAYER;
    [SerializeField] Vector3 positionalOffset;
    [SerializeField] float speed = 5;
    [SerializeField] float shakeTime;
    //[SerializeField] Transform orbRef;
    Vector3 targetPosition;
	// Use this for initialization
	void Start () {
        targetPosition = transform.position + positionalOffset;
        state = MoveState.resting; 
    }
	
	// Update is called once per frame
	void Update () {

		if(state == MoveState.moving)
        {
            Debug.Log("really should b moving");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            if(transform.position == targetPosition)
            {
                Debug.Log("Move Complete");
                state = MoveState.finished;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<CameraShake>().enabled = false;
                DIMU_Controller.canMove = true;
            }
        }
	}

    public void interact()
    {
        if(state == MoveState.resting && PLAYER.GetComponent<DIMU_Controller>().ammo > 0)
        {
            state = MoveState.moving;
            Debug.Log("MOVING");

            GetComponent<CameraShake>().enabled = true;
            DIMU_Controller.canMove = false;

            SpendAmmo(-1, false);
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
