using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActSpe : MonoBehaviour
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
			anim.Play("Enter");
			Perso.GetComponent<AttackSpécial>().enabled=true;
			PowerT.Launch1();
			Buton.SetActive(true);

		}
        
    }

}
