using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    
    [SerializeField] Transform player;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject[] bulletSpawners;
    private int[] count = {0};
    [SerializeField] float attackRange;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;

    private float timeBtwShots;
    [SerializeField] float startTimeBtwShots;

    public float currentHealth;
    public float maxHealth;

    SpriteRenderer spriteRenderer;
    Color startColor;

    Rigidbody2D rigidBody;

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        
        rigidBody = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        startColor = spriteRenderer.material.color;
    }

    // Update is called once per frame
    void Update() {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distanceToPlayer < agroRange && distanceToPlayer > attackRange) {
            // chase player
            ChasePlayer(distanceToPlayer);
        }
        else if(distanceToPlayer < attackRange) {
            AttackPlayer(count);
        }
        else if(distanceToPlayer > agroRange) {
            // stop chasing player
            StopChasingPlayer();
        }
    }

    void AttackPlayer(int[] count) {
        StopChasingPlayer();
        Transform bulletSpawn = bulletSpawners[count[0]].GetComponent<Transform>();
        if(timeBtwShots <= 0) {
            animator.SetBool("isAttacking", true);
            Instantiate(bullet, bulletSpawn.transform.position, bullet.transform.rotation);
            count[0] = (count[0] + 1) % bulletSpawners.Length;
            timeBtwShots = startTimeBtwShots;
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void ChasePlayer(float distance) {
        
        if(transform.position.x < player.position.x) {
            // enemy is to the left side
            rigidBody.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector3(-5, 5, 1);
            animator.SetBool("isWalking", true);
        }
        else if(transform.position.x > player.position.x) {
            // enemy is to the right side
            rigidBody.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector3(5, 5, 1);
            animator.SetBool("isWalking", true);
        }
    }

    void StopChasingPlayer() {
        rigidBody.velocity = new Vector2(0, 0);
        animator.SetBool("isWalking", false);
    }

    public void TakeDamage(int damage) {
        if(currentHealth == 0) {
            animator.SetBool("isDead", true);
        }
        else {
            currentHealth -= damage;
            spriteRenderer.material.color = Color.red;
        }
        Debug.Log("ENEMY HIT!");
        Invoke("revertColor", 0.50f);
    }

    void revertColor() {
        spriteRenderer.material.color = startColor;
    }

    void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, new Vector3(agroRange, 0, 0));
	}
}
