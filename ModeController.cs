using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
	[HideInInspector]
	public bool specialViewIsActive;
	public GameObject InfoText = null;
	
	private GameObject FPC;
	private GameObject optionsController;
	
	private GameObject audioBackground; // for playing background sounds 
	private GameObject audioBackground2; // for playing background sounds 
	
	[Header("To change the background while SpecialMode is active")]
	public GameObject background;
	
	private float tmpSpeed;
	private const float newWalkSpeed = 15;
	
	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	
    // Start is called before the first frame update
    void Start()
    {
		specialViewIsActive = false;
		FPC = GameObject.FindWithTag("Player");
		tmpSpeed=FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed;
		optionsController = GameObject.FindWithTag("OptionsController");
		audioBackground=optionsController.GetComponent<OptionsController>().audioBackground;
		audioBackground2=optionsController.GetComponent<OptionsController>().audioBackground2;
    }

    // Update is called once per frame
    void Update()
    {
		Reset();
        if (Input.GetKey("q") && !specialViewIsActive && !noPressKeyYet)
		{
			activateSpecialMode();
			//CanvasButtons.SetActive(true);
		}
		if (Input.GetKey("q") && specialViewIsActive && !noPressKeyYet)
		{
			deactivateSpecialMode();
			//CanvasButtons.SetActive(false);
		}
    }
	
	public void activateSpecialMode()
	{
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = newWalkSpeed;
		decay = DecayImage;
		noPressKeyYet = true;
		specialViewIsActive = true;
		InfoText.SetActive(true);
		if (background != null)
			background.SetActive(true);
		if (audioBackground2 != null)
			audioBackground2.GetComponent<AudioSource>().Pause();
	}
	
	public void deactivateSpecialMode()
	{
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = tmpSpeed;
		decay = DecayImage;
		noPressKeyYet = true;
		specialViewIsActive = false;
		InfoText.SetActive(false);
		if (background != null)
			background.SetActive(false);
		if (audioBackground2 != null)
			audioBackground2.GetComponent<AudioSource>().UnPause();
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
}
