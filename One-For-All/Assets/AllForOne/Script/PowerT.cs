using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerT : MonoBehaviour
{
	public static Image Barre;
	public float max { get; set; }

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

}
