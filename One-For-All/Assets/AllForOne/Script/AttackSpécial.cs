using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpécial : MonoBehaviour
{
	public Animator anim;
	public GameObject Perso;
	public GameObject Buton;
	public PowerT PowerT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey(KeyCode.Y))
		{
			anim.Play("Attack 1");
			StartCoroutine("waitforsec");

		}
        
    }

	IEnumerator waitforsec()
	{
		PowerT.Launch1();
		yield return new WaitForSeconds(5);
		{

			Perso.GetComponent<AttackSpécial>().enabled=false;
			Buton.SetActive(false);
		
		}
	}

}
