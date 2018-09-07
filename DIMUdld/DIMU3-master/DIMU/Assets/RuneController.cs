using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneController : Floater {

	// Use this for initialization
    [SerializeField] public float startScaleMod;
    [SerializeField] public float endScaleMod;
    [SerializeField] public float speed;

    public enum state {rising, standing, falling};
    public state _state;

    void Start () {


        transform.localScale = startScaleMod * Vector3.one;
        base.Start();
        _state = state.rising;
    }

    // Update is called once per frame
    void Update () {

        base.Update();
        if (_state == state.rising)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, endScaleMod * Vector3.one, speed * Time.deltaTime);
        }
        else if (_state == state.falling)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, startScaleMod * Vector3.one, speed * Time.deltaTime);
            if(transform.localScale == startScaleMod * Vector3.one)
            {
                Destroy(gameObject);
            }
        }

    }
}
