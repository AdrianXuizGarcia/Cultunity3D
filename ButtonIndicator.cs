using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIndicator : MonoBehaviour
{
    public Transform target;
	public GameObject indicator = null;
	
	void OnTriggerEnter(Collider other)
	{
		
		indicator.GetComponent<Renderer>().enabled = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		
		indicator.GetComponent<Renderer>().enabled = false;
	}
	
    void Update()
    {
        // Rotate every frame so it keeps looking at the target
        transform.LookAt(target);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the object on its side
        // transform.LookAt(target, Vector3.left);
    }
}
