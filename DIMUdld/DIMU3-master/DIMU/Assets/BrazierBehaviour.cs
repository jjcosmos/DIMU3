using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazierBehaviour : TriggerInteractable, IInteractable {


    //[SerializeField] Transform PLAYER;
    //[SerializeField] Transform orbRef;
    // Use this for initialization  
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void interact()
    {
        DIMU_Controller playerController = PLAYER.GetComponent<DIMU_Controller>();
        if (playerController.ammo < playerController.MAX_AMM0)
        {
            SpendAmmo(1, true);
            FXchain();
        }
    }

    private void FXchain()
    {
        
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
