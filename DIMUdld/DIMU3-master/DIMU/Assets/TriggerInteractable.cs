using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractable : MonoBehaviour {
    [SerializeField] public Transform PLAYER;
    [SerializeField] public Transform orbRef;
    // Use this for initialization
    void Start () {
        PLAYER = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        PLAYER.GetComponent<DIMU_Controller>().currentInteractTarget = transform;
    }

    void OnTriggerExit(Collider other)
    {
        PLAYER.GetComponent<DIMU_Controller>().currentInteractTarget = null;
    }

    protected void SpendAmmo(int ammoChange, bool isFull)
    {
        PLAYER.GetComponent<DIMU_Controller>().ammo += ammoChange;
        orbRef.GetChild(0).GetComponent<OrbBehaviour>().isFull = isFull;
        orbRef.GetChild(0).GetComponent<OrbBehaviour>().UpdateOrb();
    }
}
