using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusButton : MonoBehaviour {

	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	private bool objectActive;
	private GameObject optionsController;
	 
	public GameObject objectOnFocus;
	public GameObject ButtonText;
	public GameObject ccAudio;
	[Header("If None, it will take AudioSource from this object")]
	public AudioSource audioData; // for playing sounds
	
	void Start()
	{
		if (audioData == null) 
			audioData = GetComponent<AudioSource>();
		optionsController = GameObject.FindWithTag("OptionsController");
	}
	
	void OnTriggerEnter(Collider other)
	{
		ButtonText.SetActive(true);
	}
	
	void OnTriggerExit(Collider other)
	{	
		ButtonDeactivation();
	}
	
	void OnDisable()
	{	
	if (gameObject != null && ButtonText != null && objectOnFocus != null)
		ButtonDeactivation();
	}

	void OnTriggerStay(Collider other)
	{
	Reset();
		
		if (Input.GetKey("e") && !objectActive && !noPressKeyYet)
		{
			decay = DecayImage;
			objectActive = true;
			noPressKeyYet = true;
			ButtonText.SetActive(false);
			if (ccAudio != null && optionsController.GetComponent<OptionsController>().IsActiveCCAudio())
				ccAudio.SetActive(true);
			if (audioData != null)
				audioData.Play();
			objectOnFocus.GetComponent<AgeObjectController>().ActualFocus(true);
		}
		if (Input.GetKey("e") && objectActive && !noPressKeyYet)
		{
			decay = DecayImage;
			objectActive = false;
			noPressKeyYet = true;
			ButtonText.SetActive(true);
			if (ccAudio != null) 
				ccAudio.SetActive(false);
			if (audioData != null)
				audioData.Stop();
			objectOnFocus.GetComponent<AgeObjectController>().ActualFocus(false);
		}
		if (Input.GetKey("m") && objectActive && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			audioData.mute = !audioData.mute;
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
	
	private void ButtonDeactivation()
	{
		objectActive = false;
		ButtonText.SetActive(false);
		if (audioData != null)
			audioData.Stop();
		objectOnFocus.GetComponent<AgeObjectController>().ActualFocus(false);
		if (ccAudio != null) 
			ccAudio.SetActive(false);
	}
}