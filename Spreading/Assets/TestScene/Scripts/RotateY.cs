using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour {

    public float vel = 1f;
    public bool rotate = false;
	
	// Update is called once per frame
	void Update () {
        if (!rotate) return;
        transform.rotation = Quaternion.Euler(new Vector3(0, Time.time * vel, 0));
    }
}
