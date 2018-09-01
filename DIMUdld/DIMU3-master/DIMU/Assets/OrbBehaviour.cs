using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour {

    [SerializeField] Material Orb_Empty;
    [SerializeField] Material Orb_Full;
    Renderer rend;
    public bool isFull;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material = Orb_Empty;
        isFull = false;
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void UpdateOrb()
    {
        Transform childFX = transform.GetChild(0);
        if (isFull)
        {
            rend.material = Orb_Full;
            childFX.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            rend.material = Orb_Empty;
            childFX.GetComponent<ParticleSystem>().Stop();
        }
    }
}
