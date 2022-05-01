using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMain : MonoBehaviour
{
	public GameObject panelMenu;
	bool affiche = false;

	void Star()
	{
		panelMenu.SetActive(false);
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			affiche = !affiche;

			panelMenu.SetActive(affiche);

			if(affiche)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}


		}
	}
}
