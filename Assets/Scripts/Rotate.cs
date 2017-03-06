using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float rtspeed;
	void Update () {
        transform.Rotate(Vector3.up * rtspeed * Time.deltaTime);
        transform.Rotate(Vector3.right * rtspeed * Time.deltaTime);
    }
}
