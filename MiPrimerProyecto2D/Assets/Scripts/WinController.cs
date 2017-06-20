using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour {
	private float timer = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer < 0)
			SceneManager.LoadScene ("MenuSeleccionNiveles");
			
	}
}
