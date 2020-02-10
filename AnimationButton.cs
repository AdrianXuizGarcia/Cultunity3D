using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton : MonoBehaviour 
{
	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	
	private GameObject modeController;
	
	public GameObject ButtonText;
	
	private const int MaxNumObjects = 5; // How many max objects
	private int numObjects = 0;  // Actual number of objects (not null)
	private int actualObject = 0; // Iterator index

	private GameObject[] arrayObjects = new GameObject[MaxNumObjects]; // array that contains all objects
	private bool[]arrayIsFocuseable = new bool[MaxNumObjects];
	
	[Header("Objects that appear in order")]
	public GameObject Object1;
	public bool Object1_IsFocuseable;
	public GameObject Object2;
	public bool Object2_IsFocuseable;
	public GameObject Object3;
	public bool Object3_IsFocuseable;
	public GameObject Object4;
	public bool Object4_IsFocuseable;
	public GameObject Object5;
	public bool Object5_IsFocuseable;
		
	void Start()
	{
		int i = 0;
		modeController=GameObject.FindWithTag("ModeController");
		
		arrayObjects[0]=Object1; arrayIsFocuseable[0]=Object1_IsFocuseable;
		arrayObjects[1]=Object2; arrayIsFocuseable[1]=Object2_IsFocuseable;
		arrayObjects[2]=Object3; arrayIsFocuseable[2]=Object3_IsFocuseable;
		arrayObjects[3]=Object4; arrayIsFocuseable[3]=Object4_IsFocuseable;
		arrayObjects[4]=Object5; arrayIsFocuseable[4]=Object5_IsFocuseable;
		
		while (i<MaxNumObjects)
		{
			if (arrayObjects[i] != null){
				numObjects += 1;
				//arrayObjects[i].SetActive(true);
			}
			i++;
		}
	}
	
	void NextObject()
	{
		for (int i = 0; i < numObjects;i++){
			arrayObjects[i].GetComponent<AgeObjectController>().Focus(true);
			arrayObjects[i].GetComponent<AgeObjectController>().ActualFocus(false);
		}
		if (actualObject != 0){
			if (!arrayIsFocuseable[actualObject-1]){
				while (!arrayIsFocuseable[actualObject-1] && actualObject<MaxNumObjects){
					actualObject += 1;
				}
			}
			arrayObjects[actualObject-1].GetComponent<AgeObjectController>().Focus(false);
			arrayObjects[actualObject-1].GetComponent<AgeObjectController>().ActualFocus(true);
		}
		actualObject += 1;
		//Debug.Log("--------------------------------");
	}
	
	void ResetObjects()
	{
		actualObject=0;
		for (int i = 0; i < numObjects;i++){
			arrayObjects[i].GetComponent<AgeObjectController>().Focus(false);
			arrayObjects[i].GetComponent<AgeObjectController>().ActualFocus(false);
			//if (arrayIsFocuseable[i])
			//	arrayObjects[i].SetActive(false);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!modeController.GetComponent<ModeController>().specialViewIsActive)
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
			} else {
				decay = DecayImage;
				noPressKeyYet = true;
				ResetObjects();
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
	}
		

}