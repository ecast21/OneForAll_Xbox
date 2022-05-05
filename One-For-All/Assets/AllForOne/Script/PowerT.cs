using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerT : MonoBehaviour
{
	public static Image Barre;
	public float max { get; set; }

	public GameObject Perso;
	public GameObject Buton;

	private float Valeur;
	public float valeur
	{
		get { return Valeur; }

		set
		{
			Valeur = Mathf.Clamp (value, 0, max);
			Barre.fillAmount = (1 / max) * Valeur;
		}

	}


	// Start is called before the first frame update
	void Start()
	{
		Barre = GetComponent<Image>();
		max = 200;
		valeur = 0;


	}



	public void Launch()
	{
		valeur +=3;

	}



	public void Launch1()
	{
		valeur -=200;

	}

	void Update()
	{
		if(valeur>=80)
		{
			Buton.SetActive(true);
			Perso.GetComponent<AttackSpécial>().enabled=true;
		}
	}

}
