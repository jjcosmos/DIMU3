using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosOnSceneLoad : MonoBehaviour {

    [SerializeField] Transform startingPosition;
	// Use this for initialization
	void Start () {
        transform.position = startingPosition.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
