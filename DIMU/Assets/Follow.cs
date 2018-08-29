using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    // Use this for initialization
    [SerializeField] Transform Target;
    [SerializeField] float VerticalMod = 2;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Target.position + Vector3.up * VerticalMod;
	}
}
