using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;
	public Animator anim;

	public HealthBar healthBar;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth (maxHealth);

	}


	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

	}

	void Update()
	{	
		if(currentHealth <= 0)
		{	
			anim.Play("Dead");
			GetComponent<PlayerAttack>().enabled = false;
			GetComponent<MovePlayer>().enabled = false;
			StartCoroutine("waitforsec");
		}
	}

	IEnumerator waitforsec()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
