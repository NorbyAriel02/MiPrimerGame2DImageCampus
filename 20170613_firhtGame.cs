using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour 
{
	public bool hasKey;
	
	//private varible
	private Dictionary<string, int> Inventory; 
	private HUDController hud;
	void Awake()
	{
		Inventory =  new Dictionary<string, int>();
		Inventory.Add("key", 0);
		Inventory.Add("Weapon02", 0);
	}
	
	void Update()
	{
		
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

/*Add al GameController*/
public class HUDController : MonoBehaviour 
{	
	public Text BulletsText;
	public Text ScoreText;
	public Text TimeText;
	public Slider HealthSlice;
	public Image[] listWeapon;
	
	private PlayerInventory Inventory;
	
	void Awake()
	{
		Inventory = player.GetComponet<PlayerInventory>();
				
		if(Inventory.GetElemnt("Weapon02") > 0)
			listWeapon[1].Enable = true;
	}
	
	public void SetBullets(float bullets)
	{
		BulletsText.text = "Bullets: " + bullets.toString();
	}
	
	public float GetBullets()
	{
		string[] bullets = BulletsText.text.Split(':');
		return convert.ToFloat(bullets[1]);
	}
	
	
	public void SetScore(float value)
	{
		ScoreText.text = "Score: " + value.toString();
	}
	
	public float GetScore()
	{
		string[] score = ScoreText.text.Split(':');
		return convert.ToFloat(score[1]);
	}
	
	
	public void SetHealth(float value)
	{
		HealthSlice.value = value;
	}
	
	public float GetHealth()
	{
		return HealthSlice.value;
	}
	
	
	public void SetTime(float time)
	{
		TimeText.text = "Time: " + time.toString();
	}
	
	public float GetTime()
	{
		string[] time = TimeText.text.Split(':');
		return convert.ToFloat(time[1]);
	}
	
	public void SetWeapon02()
	{
		if(Inventory.GetElemnt("Weapon02") > 0)
			listWeapon[1].Enable = true;

	}
}

public class PlayerHealth : MonoBehaviour 
{	
	public float Health = 100;	
	public GameObject gameController;
	//private varible
	private HUDController hud;
	void Awake()
	{
		hud = gameController.GetComponet<HUDController>();
		hud.SetHealth(Health/100);
	}	
	
	void TakeDanger()
	{
		Health -= DangerPerShoot;
		hud.SetHealth(Health/100);
	}
}

public class EnemyHealth : MonoBehaviour 
{
	public GameObject gameController;
	//private varible
	private HUDController hud;
	
	void TakeDanger()
	{
		Health -= DangerPerShoot;
		hud.SetScore(hud.GetScore()+20);
	}
}

public class ProjectileController : MonoBehaviour 
{
	public GameObject gameController;
	//private varible
	private HUDController hud;
	
	void Explosion()
	{
		if(enemyHealth != null)
		{
			enemyHealth.TakeDanger(DangerPerShoot);			
		}
	}
}

 public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
{
	var dir = (body.transform.position - explosionPosition);
	float wearoff = 1 - (dir.magnitude / explosionRadius);
	body.AddForce(dir.normalized * explosionForce * wearoff);
}

public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier)
{
	var dir = (body.transform.position - explosionPosition);
	float wearoff = 1 - (dir.magnitude / explosionRadius);
	Vector3 baseForce = dir.normalized * explosionForce * wearoff;
	body.AddForce(baseForce);

	float upliftWearoff = 1 - upliftModifier / explosionRadius;
	Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
	body.AddForce(upliftForce);
}

/*un sprite con Rigidbody2D y BoxCollider2D en trigger*/
class StairController()
{
	public float speed = 2;
	void OnTriggerStay2D(Collider2D other)
    {        
		if(other.gameObject.tag == "Player" && Input.GetKey("up"))
		{
			Vector3 CurrentPos = other.gameObject.transform.position;
			float x = CurrentPos.x;
			float y = CurrentPos.y * speed * Time.delaTime;
			Vector3 newPos = new Vector3(x, y, 0);
			other.gameObject.transform.position = newPos;
		}
    }
}

class PlayerMove()
{
	public bool key = false;
	void OnCollisionEnter2D(Collision2D other)
    {        
		if(other.gameObject.tag == "Key")
		{
			key = true;
			Destroy(other.gameObject);
		}
    }
}

class DoorController()
{
	public float speed = 2;
	void OnTriggerStay2D(Collider2D other)
    {        
		if(other.gameObject.tag == "Player")
		{
			PlayerMove HasKey = other.gameObject.GetComponent<PlayerMove>();
			if(
			Vector3 CurrentPos = other.gameObject.transform.position;
			float x = CurrentPos.x;
			float y = CurrentPos.y * speed * Time.delaTime;
			Vector3 newPos = new Vector3(x, y, 0);
			other.gameObject.transform.position = newPos;
		}
    }
}