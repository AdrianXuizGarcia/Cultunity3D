using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton_OLD : MonoBehaviour {

// DEPRECATED CLASS
public GameObject boton;
public float Distance;
public GameObject ButtonText = null;

void OnTriggerEnter(Collider other)
	{
		
		ButtonText.SetActive(true);
	}
	
void OnTriggerExit(Collider other)
	{
		
		ButtonText.SetActive(false);
	}

void OnTriggerStay(Collider other)
	{
		
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Información: Es arte");
		}
	}
	/*
 void Update()
    {
        // Process a mouse button click.
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                    if (hit.collider.gameObject == boton)
                    {
						Distance = Vector3.Distance(boton.transform.position,Camera.main.gameObject.transform.position);
						if (Distance < 2) {
							Debug.Log("Hit");
						} else {
							Debug.Log("Too far");
						}
                    }
            }
        }
    }*/
}
