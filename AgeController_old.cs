using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeController_old : MonoBehaviour
{

    public bool ageMenuIsActive = false;
    public GameObject controllerUI;
	public ModeController modeController;
	
	public GameObject FPC;
	
	private GameObject ageDisplay;
	public int age;
	
	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	
    // Start is called before the first frame update
    void Start()
    {
		age = 1;
		controllerUI.SetActive(false);
		ageMenuIsActive = false;
		ageDisplay = GameObject.FindWithTag("AgeDisplayController");
		//ageDisplay.GetComponent<AgeDisplay>().UpdateDisplay(age);
	}

    // Update is called once per frame
    void Update()
    {
		Reset();
       /* if (Input.GetKey("p") && !ageMenuIsActive && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Pause();
		}
		if (Input.GetKey("p") && ageMenuIsActive && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Resume(age);
		}*/
		if (Input.GetKey("1") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Resume(1);
		}
		if (Input.GetKey("2") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Resume(2);
		}
		if (Input.GetKey("3") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Resume(3);
		}
		if (Input.GetKey("4") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Resume(4);
		}
		if (Input.GetKey("5") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Resume(5);
		}
		if (Input.GetKey("6") && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Resume(6);
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

	// DEPRECATED
    public void Resume(int newAge)
    {
		int i; 
		
		// Asign the new Age
		age = newAge;
		
        // Make the menu UI invisible
        controllerUI.SetActive(false);

        // Resume the game time
        Time.timeScale = 1f;

        ageMenuIsActive = false;
		
		ageDisplay.GetComponent<AgeDisplay>().UpdateDisplay(age);

		// Turn off Special Mode if activated
		modeController.deactivateSpecialMode();
		
		//Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;  
			
		// Lock the mouse again
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_MouseLook.m_cursorIsLocked = true;
    }


    public void Pause()
    {
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_MouseLook.m_cursorIsLocked = false;
		
        // Make the menu UI visible
        controllerUI.SetActive(true);

        // Stop the game time
        Time.timeScale = 0f;

        ageMenuIsActive = true;
		
		//modeController.deactivateSpecialMode();
		}


    public void LoadMenu()
    {
        Debug.Log("LoadMenu");
        Time.timeScale = 1f;
        //SceneManager.LoadScene("MenuScene");
    }


    public void Quit()
    {
        Debug.Log("Quit");
                // Exit in case it's a deployed application or stop the editor in case it's running under UnityEditor
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit ();
        #endif
    }

}
