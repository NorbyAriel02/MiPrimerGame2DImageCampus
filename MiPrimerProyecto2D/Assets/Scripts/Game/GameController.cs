using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // Use this for initialization
    private string level;
    private string nextLevel;
	void Start () {
        //GameObject Player = GameObject.FindGameObjectWithTag ("Player");
        level = SceneManager.GetActiveScene().name;
        SetNextLevel();
        PlayerPrefs.SetString("CurrentLevel", level);        
	}

    void SetNextLevel()
    {
        string[] convertLevel = level.Split('l');
        int numberLevel = Convert.ToInt32(convertLevel[1]);
        numberLevel++;
        nextLevel = "Nivel" + numberLevel;
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene ("MenuPrincipal");
			
	}

	public void gameOver()
	{
		SceneManager.LoadScene ("GameOver");
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
			SceneManager.LoadScene (nextLevel);
	}
}