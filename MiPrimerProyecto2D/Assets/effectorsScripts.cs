using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectorsScripts : MonoBehaviour {
	public PointEffector2D explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			explosion.forceMagnitude = 600;
		}
		else
			explosion.forceMagnitude = 0;
	}
}
