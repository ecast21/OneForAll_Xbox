using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int Health;
	public GameObject Enem;
	public GameObject DamEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Health <= 0)
		{
			Enem.GetComponent<Detruit> ().enabled = true;
		
		}
	}

	public void TakeDamage(int damage)
	{
		Instantiate(DamEffect, transform.position, Quaternion.identity);
		Health -= damage;
		Debug.Log ("damage TAKEN !");
	}

}
