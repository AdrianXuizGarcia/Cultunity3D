using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAndAudioButton_old : MonoBehaviour {

	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	 
	public GameObject Image;
	public GameObject ButtonText;
	
	public Material infoMaterial;
	//private Material originalMat;

	public AudioSource audioData; // for playing sounds
	
	void Start()
	{
		//originalMat = gameObject.GetComponent<Renderer>().material;
		if (audioData == null) 
			audioData = GetComponent<AudioSource>();
		if (infoMaterial == null) 
			infoMaterial = Resources.Load("Materials/InfoImage", typeof(Material)) as Material;
	}
	
	void OnTriggerEnter(Collider other)
	{
		ButtonText.SetActive(true);
		//gameObject.GetComponent<Renderer>().material = infoMaterial;
	}
	
	void OnTriggerExit(Collider other)
	{	
		ButtonText.SetActive(false);
		Image.SetActive(false);
		audioData.Stop();
		//gameObject.GetComponent<Renderer>().material = originalMat;
	}

	void OnTriggerStay(Collider other)
	{
	Reset();
		
		if (Input.GetKey("e") && !Image.activeSelf && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Image.SetActive(true);
			ButtonText.SetActive(false);
			audioData.Play();
		}
		if (Input.GetKey("e") && Image.activeSelf && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Image.SetActive(false);
			ButtonText.SetActive(true);
			audioData.Stop();
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
	

}