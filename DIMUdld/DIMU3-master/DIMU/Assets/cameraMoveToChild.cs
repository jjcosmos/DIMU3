using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveToChild : MonoBehaviour {

    // Use this for initialization
    public bool moveToTarget = false;
    public bool inPosition = true;
    Transform childPosition;
    [SerializeField] float speed = 1;
    [SerializeField] float minSnapDistance = .2f;
    [SerializeField] float waitTime = 1f;

	void Start () {
        
        childPosition = transform.parent.transform.GetChild(0).transform;
        inPosition = true;

        
        if (childPosition.position != Camera.main.transform.position)
        {
            inPosition = false;
        }
        

        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if(Vector3.Distance(childPosition.position, Camera.main.transform.position) > .1f)
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
            Debug.Log("startinvoke");
            Invoke("MakeMove", waitTime);
            Debug.Log("endinvoke");
            //Camera.main.GetComponent<CameraShake>().enabled = true;
            //Invoke("endShake", Camera.main.GetComponent<CameraShake>().shakeDuration);

        }
        
        
	}

    void endShake()
    {
        Camera.main.GetComponent<CameraShake>().enabled = false;
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
