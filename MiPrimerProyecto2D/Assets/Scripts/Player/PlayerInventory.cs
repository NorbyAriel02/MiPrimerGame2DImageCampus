using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
	public bool HasKey = false;
	public Image[] ImgInvetoryWeapons;

	//private varible
	private Dictionary<string, int> Inventory; 
	private PlayerAttack02 Attack01;
	private PlayerAttack Attack02;
	void Awake()
	{
		Inventory =  new Dictionary<string, int>();
		Inventory.Add("key", 0);
		Inventory.Add("weapon02", 0);
		ImgInvetoryWeapons [1].color = new Color (0, 0, 0, 0);
		GameObject GO = GameObject.FindGameObjectWithTag ("Player");
		//pequeño error al crear los scripts inverti los numeros
		Attack01 = GO.GetComponent<PlayerAttack02> ();
		Attack02 = GO.GetComponent<PlayerAttack> ();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1))
			SelectWeapon01 ();

		if (Input.GetKeyDown (KeyCode.Alpha2))
			SelectWepon02 ();
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
		ImgInvetoryWeapons [2].transform.position = ImgInvetoryWeapons [0].transform.position;
		Attack02.enabled = false;
		Attack01.enabled = true;
	}

	void SelectWepon02()
	{
		if (GetElemnt ("weapon02") <= 0)
			return;

		Attack01.enabled = false;
		Attack02.enabled = true;
		ImgInvetoryWeapons [2].transform.position = ImgInvetoryWeapons [1].transform.position;
	}

	public void ShowWeapon02()
	{
		ImgInvetoryWeapons [1].color = new Color (0, 0, 0, 1);
	}
}
