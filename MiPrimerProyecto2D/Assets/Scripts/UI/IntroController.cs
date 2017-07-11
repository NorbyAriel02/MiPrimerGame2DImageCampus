using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {
	public GameObject Brick;
	public float Timer = 1;
	public float speed = 1;

	private Vector3 FromPos;
	private Vector3 ToPos;
	private Vector3 FinalPos;
	private float exitTime = 10;
	//private float[,] matrixCartel;
	private GameObject cloneBrick = null;
	private float Acumulador = 0;
	void Awake()
	{
		FromPos = new Vector3 (10, 10, 0);
		ToPos = new Vector3 (-5, 4, 0);
		//matrixCartel = new float[55, 25];
	}

	void Update () {		
		GoIntro ();
	}

	void GoIntro()
	{
		if (Timer > 1) 
		{
			cloneBrick = Instantiate (Brick, FromPos, Quaternion.identity);
			Timer = 0;
			if(Acumulador > 0)
				ToPos = new Vector3 (-5+Acumulador, 4-Acumulador, 0);

			Acumulador = Acumulador+0.5f;
		}

		Timer += Time.deltaTime;
		exitTime -= Time.deltaTime;

		if(cloneBrick != null)
			cloneBrick.transform.position = Vector3.Lerp (FromPos, ToPos, Timer * speed);

		if (exitTime <= 0)
			SceneManager.LoadScene ("MenuPrincipal");
	}
}
