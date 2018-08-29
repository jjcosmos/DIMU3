using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour {

    // Use this for initialization
    [SerializeField] Transform Target;
    [SerializeField] float rotationSpeed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Target.position, Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
