using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveToChild : MonoBehaviour {

    // Use this for initialization
    public bool moveToTarget = false;
    public bool inPosition = false;
    Transform childPosition;
    [SerializeField] float speed = 1;
    [SerializeField] float minSnapDistance = .2f;
    [SerializeField] float waitTime = 1f;

	void Start () {
        childPosition = transform.GetChild(0).transform;
	}
	
	// Update is called once per frame
	void Update () {

        if(childPosition.position != Camera.main.transform.position)
        {
            inPosition = false;
        }
        

        if (moveToTarget)
        {
            float step = speed * Vector3.Distance(Camera.main.transform.position, childPosition.position) * Time.deltaTime;
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, childPosition.position, step);
        }
    
        
        if(Vector3.Distance(Camera.main.transform.position, childPosition.position) < minSnapDistance && !inPosition && moveToTarget)
        {
            Camera.main.transform.position = childPosition.position;
            moveToTarget = false;
            inPosition = true;
            print("startinvoke");
            Invoke("MakeMove", waitTime);
            print("endinvoke");

        }
        
        
	}

    void MakeMove()
    {
        DIMU_Controller.canMove = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && !inPosition && !moveToTarget)
        {
            DIMU_Controller.canMove = false;
            moveToTarget = true;
            print("triggerEntered");
            
        }
    }
}
