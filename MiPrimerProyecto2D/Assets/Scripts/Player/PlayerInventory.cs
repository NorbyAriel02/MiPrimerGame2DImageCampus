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
		Inventory.Add("Weapon02", 0);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "key") {
			Destroy (other.gameObject);
			HasKey = true;
		}
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

}
