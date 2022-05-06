using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatEnem : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.transform.CompareTag("Enemy"))
		{
			Enemy enemy = collision.transform.GetComponent<Enemy>();
			enemy.TakeDamage(8);

		}
	}
}
