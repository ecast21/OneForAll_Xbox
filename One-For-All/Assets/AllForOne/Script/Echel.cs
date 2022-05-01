using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovePlayerNamespace
{

public class Echel : MonoBehaviour
{
	private bool isInRange;
	public MovePlayer movePlayer;
	public GameObject Button;


    void Awake()
    {
		movePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
        
    }

    // Update is called once per frame
    void Update()
    {
		 if(movePlayer.isGrimp && Input.GetKeyDown(KeyCode.B))
		 {
				movePlayer.isGrimp = false;
				return;
		 }

		 if(isInRange && Input.GetKeyDown(KeyCode.B))
		 {
				movePlayer.isGrimp = true;
		 }
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			isInRange = true;
			Button.SetActive(true);

		}
			

	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			isInRange = false;
			movePlayer.isGrimp = false;
			Button.SetActive(false);

		}
	
	}
   }
  }


			
