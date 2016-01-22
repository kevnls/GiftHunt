using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //find the panel and the text field and enable them for a short time and add text
        GameObject messageCanvas = GameObject.Find("MessageCanvas");
        Destroy(this.gameObject);
    }
}
