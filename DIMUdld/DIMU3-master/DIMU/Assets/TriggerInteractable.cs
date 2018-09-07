using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteractable : MonoBehaviour {
    [SerializeField] public Transform PLAYER;
    [SerializeField] public Transform orbRef;
    public bool requiresPower;
    public Transform runeFX;
    Transform rune;
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

    public void spawnRune(Vector3 positionOffset)
    {
        rune =  Instantiate(runeFX, transform.position + positionOffset, Quaternion.identity);
        rune.parent = transform;
        rune.GetComponent<RuneController>().startScaleMod = .1f;
        rune.GetComponent<RuneController>().endScaleMod = 2f;
        rune.GetComponent<RuneController>().speed = 5f;
    }

    public void despawnRune()
    {
        rune.GetComponent<RuneController>()._state = RuneController.state.falling;
    }
}
