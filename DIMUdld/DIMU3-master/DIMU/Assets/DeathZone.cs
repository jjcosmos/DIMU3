using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

	// Use this for initialization

    enum moveState {resting, moving, done };
    moveState state;

    [SerializeField] Transform resetCameraTarget;
    [SerializeField] float resetSpeed;
    Vector3 startingPos;
	void Start () {

        state = moveState.resting;
        
	}

    void onEnable()
    {
        state = moveState.resting;
    }
	
	// Update is called once per frame
	void Update () {
		
        if(state == moveState.moving)
        {
            Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, resetCameraTarget.position, Time.deltaTime * resetSpeed);
            if(Camera.main.transform.position == resetCameraTarget.position)
            {
                DIMU_Controller.canMove = true;
                state = moveState.resting;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && state == moveState.resting)
        {
            DIMU_Controller.canMove = false;
            state = moveState.moving;
            Debug.Log(other.name);
            other.transform.parent.transform.position = other.transform.parent.GetComponent<DIMU_Controller>().startingPos;
            startingPos = Camera.main.transform.position;


        }
    }
}
