using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAndAudioButton : MonoBehaviour {

	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	
	private GameObject modeController;
	private GameObject optionsController;
	
	public GameObject ButtonText;
	public GameObject ccAudio;
	
	private const int MaxNumObjects = 5; // How many max objects
	private int numObjects = 0;  // Actual number of objects (not null)
	private int actualObject = 0; // Iterator index

	private GameObject[] arrayObjects = new GameObject[MaxNumObjects]; // array that contains all objects
	
	// TODO: Making a special material for the button
	//public Material infoMaterial;
	//private Material originalMat;
	
	[Header("Objects that appear in order")]
	public GameObject Image1;
	public GameObject Image2;
	public GameObject Image3;
	public GameObject Image4;
	public GameObject Image5;
	
	[Header("If None, it will take AudioSource from this object")]
	public AudioSource audioData; // for playing sounds
	
	void Start()
	{			
		int i = 0;
		
		modeController=GameObject.FindWithTag("ModeController");
		optionsController = GameObject.FindWithTag("OptionsController");
		//originalMat = gameObject.GetComponent<Renderer>().material;
		if (audioData == null) 
			audioData = GetComponent<AudioSource>();
		//if (infoMaterial == null) 
		//	infoMaterial = Resources.Load("Materials/InfoImage", typeof(Material)) as Material;
		
		arrayObjects[0]=Image1;
		arrayObjects[1]=Image2;
		arrayObjects[2]=Image3;
		arrayObjects[3]=Image4;
		arrayObjects[4]=Image5;
		
		while (i<MaxNumObjects)
		{
			if (arrayObjects[i] != null){
				numObjects += 1;
				arrayObjects[i].SetActive(false);
			}
			i++;
		}
	}
	
	void NextObject()
	{
		for (int i = 0; i < numObjects;i++){
			arrayObjects[i].SetActive(false);
		}
		arrayObjects[actualObject].SetActive(true);
		if (actualObject >= numObjects){
			actualObject=0;
		} else {
			actualObject += 1;
		}
	}
	
	void ResetObjects()
	{
		actualObject=0;
		for (int i = 0; i < numObjects;i++){
			arrayObjects[i].SetActive(false);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		ButtonText.SetActive(true);
		//gameObject.GetComponent<Renderer>().material = infoMaterial;
	}
	
	void OnTriggerExit(Collider other)
	{	
		ButtonDeactivation();
	}
	
	void OnDisable()
	{	
	if (gameObject != null && ButtonText != null)
		ButtonDeactivation();
	}

	void OnTriggerStay(Collider other)
	{
		Reset();
		if (Input.GetKey("e") && !noPressKeyYet && !modeController.GetComponent<ModeController>().specialViewIsActive)
		{
			if (!(actualObject == numObjects))
			{
				decay = DecayImage;
				noPressKeyYet = true;
				NextObject();
				ButtonText.SetActive(false);
				if (audioData != null && !audioData.isPlaying)
					audioData.Play();
				if (ccAudio != null && optionsController.GetComponent<OptionsController>().IsActiveCCAudio())
					ccAudio.SetActive(true);
			} else {
				decay = DecayImage;
				noPressKeyYet = true;
				ResetObjects();
				ButtonText.SetActive(true);
				if (audioData != null)
					audioData.Stop();
				if (ccAudio != null) 
					ccAudio.SetActive(false);
			}
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
		ButtonText.SetActive(false);
		ResetObjects();
		if (audioData != null) 
			audioData.Stop();
		if (ccAudio != null) 
			ccAudio.SetActive(false);
	}

}