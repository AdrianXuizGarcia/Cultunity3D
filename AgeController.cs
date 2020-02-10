using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeController : MonoBehaviour
{
	private GameObject FPC;
	private GameObject modeController;
	private GameObject ageDisplay;
	private int age;
	
	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	
    // Start is called before the first frame update
    void Start()
    {
		age = 1;
		ageDisplay = GameObject.FindWithTag("AgeDisplayController");
		FPC = GameObject.FindWithTag("Player");
		modeController = GameObject.FindWithTag("ModeController");
	}

    // Update is called once per frame
    void Update()
    {
		Reset();
		if (Input.GetKey("1") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			ChangeAge(1);
		}
		if (Input.GetKey("2") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			ChangeAge(2);
		}
		if (Input.GetKey("3") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			ChangeAge(3);
		}
		if (Input.GetKey("4") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			ChangeAge(4);
		}
		if (Input.GetKey("5") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			ChangeAge(5);
		}
		if (Input.GetKey("6") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			ChangeAge(6);
		}

    }
	
	private void Reset()
	{
		 if(noPressKeyYet && decay > 0)
		 {
			 decay -= Time.deltaTime;
		 }
		 if(decay < 0)
		 {
			 decay = 0;
			 noPressKeyYet = false;
		 }
 }

    public void ChangeAge(int newAge)
    {
		int i; 
		
		// Asign the new Age
		age = newAge;
		
		ageDisplay.GetComponent<AgeDisplay>().UpdateDisplay(age);

		// Turn off Special Mode if activated
		modeController.GetComponent<ModeController>().deactivateSpecialMode();
		
		//Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;  
			
		// Lock the mouse again
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_MouseLook.m_cursorIsLocked = true;
    }
	
	public int ActualAge()
	{
		return age;
	}
}
