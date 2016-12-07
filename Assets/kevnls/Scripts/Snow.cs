using UnityEngine;
using System.Collections;

public class Snow : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        //keep the attached transform faced one direction
        transform.Rotate(0, 25, 0);
	}
}
