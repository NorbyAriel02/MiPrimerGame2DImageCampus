using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	public bool HasKey = false;
	// Use this for initialization

	//private varible
	private Dictionary<string, int> Inventory; 

	void Awake()
	{
		Inventory =  new Dictionary<string, int>();
		Inventory.Add("key", 0);
		Inventory.Add("weapon02", 0);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
			Debug.Log("Funciona");

		if (Input.GetKeyDown (KeyCode.Alpha2))
			Debug.Log ("");
	}

	public void SetElement(string nameKey, int value)
	{
		if (Inventory.ContainsKey(nameKey))
			Inventory[nameKey] += value;
		else
			Inventory.Add(nameKey, value);
	}

	public int GetElemnt(string nameKey)
	{
		if (!Inventory.ContainsKey(nameKey))
			return 0;

		return Inventory[nameKey];
	}

	void SelectWeapon01()
	{
		
	}

	void SelectWepon02()
	{
		if (GetElemnt ("weapon02"))
			return;


	}
}
