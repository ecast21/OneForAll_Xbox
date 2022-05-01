using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	private float timeBtwAttack;
	public float startTimeBtAttack;

	public Transform attackPos;
	public LayerMask whatIsEnemies;
	public float attackRangeX;
	public float attackRangeY;
	public int damage;
	public Animator playerAnim;
	public PowerT PowerT;

	// Start is called before the first frame update
	void Start()
	{

	}


	void Update()
	{
		if(timeBtwAttack <= 0)
		{
			if(Input.GetKey(KeyCode.X))
			{
				
				playerAnim.SetTrigger("Attack");
				Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
			for(int i = 0; i < enemiesToDamage.Length; i++)
			{
				enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
				PowerT.Launch();
		    }

			timeBtwAttack = startTimeBtAttack;
		  }

		}else{
		   timeBtwAttack -= Time.deltaTime;
	   }
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
	}
  }


