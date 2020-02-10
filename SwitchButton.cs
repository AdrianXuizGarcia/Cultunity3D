using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour {

	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	public GameObject ButtonText;
	
	private GameObject[] images = new GameObject[5];
	[Header("Images that appear, all at same time")]
	public GameObject Image1;
	public GameObject Image2;
	public GameObject Image3;	
	public GameObject Image4;
	public GameObject Image5;

	
	private bool isTriggered;
	
	void Start()
	{
		isTriggered = false;
		images[0]=Image1;
		images[1]=Image2;
		images[2]=Image3;
		images[3]=Image4;
		images[4]=Image5;
		ActivateImages(false);
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
	if (gameObject != null && ButtonText != null)
		ButtonDeactivation();
		isTriggered=false;
		ActivateImages(false);
	}

	void OnTriggerStay(Collider other)
	{
	Reset();
		
		if (Input.GetKey("e") && !isTriggered && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			//ButtonText.SetActive(false);
			isTriggered=true;
			ActivateImages(true);
		}
		if (Input.GetKey("e") && isTriggered && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			//ButtonText.SetActive(true);
			isTriggered=false;
			ActivateImages(false);
		}
	}

	private void ActivateImages(bool active)
	{
		for (int i = 0; i<5; i++)
		if (images[i]!=null)
			images[i].SetActive(active);
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
	}
	

}