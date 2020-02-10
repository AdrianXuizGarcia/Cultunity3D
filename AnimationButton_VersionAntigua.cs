using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton_VersionAntigua : MonoBehaviour 
{
	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
	
	public ModeController modeController;
	
	public GameObject ButtonText;
	
	private const int MaxNumObjects = 5; // How many max objects
	private int numObjects = 0;  // Actual number of objects (not null)
	private int actualObject = 0; // Iterator index

	private AgeObjectController[] arrayObjects = new AgeObjectController[MaxNumObjects]; // array that contains all objects
	private bool[]arrayIsFocuseable = new bool[MaxNumObjects];
	
	[Header("Objects that appear in order")]
	public AgeObjectController Object1;
	public bool Object1_IsFocuseable;
	public AgeObjectController Object2;
	public bool Object2_IsFocuseable;
	public AgeObjectController Object3;
	public bool Object3_IsFocuseable;
	public AgeObjectController Object4;
	public bool Object4_IsFocuseable;
	public AgeObjectController Object5;
	public bool Object5_IsFocuseable;
		
	void Start()
	{
		int i = 0;
		//modeController=GameObject.FindWithTag("ModeController");
		
		arrayObjects[0]=Object1; arrayIsFocuseable[0]=Object1_IsFocuseable;
		arrayObjects[1]=Object2; arrayIsFocuseable[1]=Object2_IsFocuseable;
		arrayObjects[2]=Object3; arrayIsFocuseable[2]=Object3_IsFocuseable;
		arrayObjects[3]=Object4; arrayIsFocuseable[3]=Object4_IsFocuseable;
		arrayObjects[4]=Object5; arrayIsFocuseable[4]=Object5_IsFocuseable;
		
		while (i<MaxNumObjects)
		{
			if (arrayObjects[i] != null)
				numObjects += 1;
			i++;
		}
	}
	
	void NextObject()
	{
		for (int i = 0; i < numObjects;i++)
			arrayObjects[i].Focus(true);
		if (actualObject != 0){
			if (!arrayIsFocuseable[actualObject-1]){
				while (!arrayIsFocuseable[actualObject-1] && actualObject<MaxNumObjects){
					actualObject += 1;
				}
			}
			arrayObjects[actualObject-1].Focus(false);
			arrayObjects[actualObject-1].ActualFocus(true);
		}
		actualObject += 1;
	}
	
	void ResetObjects()
	{
		actualObject=0;
		for (int i = 0; i < numObjects;i++){
			arrayObjects[i].Focus(false);
			arrayObjects[i].ActualFocus(false);
			//arrayObjects[i].SetActive(false);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!modeController.specialViewIsActive)
			ButtonText.SetActive(true);
	}
		
		
	void OnTriggerExit(Collider other)
	{	
		ButtonText.SetActive(false);
		//Image.SetActive(false);
		//audioData.Stop();
		ResetObjects();
	}

	void OnTriggerStay(Collider other)
	{
		Reset();
		
		if (Input.GetKey("h") && !noPressKeyYet && !modeController.specialViewIsActive)
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
		

}