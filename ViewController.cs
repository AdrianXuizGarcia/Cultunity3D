using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
	public Camera cam1;
	public Camera cam2;
	public GameObject InfoText;
	
	[HideInInspector]
	public GameObject indicator;
	[HideInInspector]
	public GameObject light;

	void Start()
	{
		cam1.enabled = true;
		cam2.enabled = false;
		indicator = GameObject.FindWithTag("PlayerIndicator");
		indicator.GetComponent<Renderer>().enabled = false;
		light = GameObject.FindWithTag("PlayerLight");
		InfoText.SetActive(false);
	}

	void Update()
	{

		if (Input.GetKeyDown("r")) {
			if (cam1.enabled)
				InfoText.SetActive(true);
			else 
				InfoText.SetActive(false);
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
			indicator.GetComponent<Renderer>().enabled = !indicator.GetComponent<Renderer>().enabled;
			light.SetActive(!light.activeSelf);
		}
	}
}
