using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpécial : MonoBehaviour
{
	public Animator anim;
	public GameObject Perso;
	public GameObject Buton;
	public GameObject Frap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey(KeyCode.B))
		{
			anim.Play("Attack 1");
			StartCoroutine("waitforsec");
			StartCoroutine("waitforsec1");

		}
        
    }

	IEnumerator waitforsec()
	{
		yield return new WaitForSeconds(25);
		{

			Perso.GetComponent<AttackSpécial>().enabled=false;
			Buton.SetActive(false);
			Frap.SetActive(false);
		
		}
	}

	IEnumerator waitforsec1()
	{
		Frap.SetActive(true);
		yield return new WaitForSeconds(2);
		{

			Frap.SetActive(false);

		}
	}

}
