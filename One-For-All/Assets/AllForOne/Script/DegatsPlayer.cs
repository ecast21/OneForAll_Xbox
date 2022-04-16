using UnityEngine;

public class DegatsPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.transform.CompareTag("Player"))
		{
		    PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
		    playerHealth.TakeDamage(15);
        
		}
	}
}
