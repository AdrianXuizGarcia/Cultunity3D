using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIndicator : MonoBehaviour
{

	private GameObject player;
	private GameObject indicator;
	
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		indicator = GameObject.FindWithTag("PlayerIndicator");
	}

    // Update is called once per frame
    void Update()
    {
        indicator.transform.position = new Vector3(player.transform.position.x, indicator.transform.position.y, player.transform.position.z); 
    }
}
