using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeDisplay : MonoBehaviour
{
	private const int NumAges = 6; // How many Ages 
	//[HideInInspector]
	private GameObject[] arrayTextInfo = new GameObject[NumAges]; // array that contains all ages (define its size on the constant NumAges)
	public GameObject Epoca1_Text;
	public GameObject Epoca2_Text;
	public GameObject Epoca3_Text;
	public GameObject Epoca4_Text;
	public GameObject Epoca5_Text;
	public GameObject Epoca6_Text;
	
	
    // Start is called before the first frame update
    void Start()
    {
		arrayTextInfo[0]=Epoca1_Text;
		arrayTextInfo[1]=Epoca2_Text;
		arrayTextInfo[2]=Epoca3_Text;
		arrayTextInfo[3]=Epoca4_Text;
		arrayTextInfo[4]=Epoca5_Text;
		arrayTextInfo[5]=Epoca6_Text;
		UpdateDisplay(1);
    }
	
	public void UpdateDisplay(int age)
	{
			// Desactive all the Age Info 
		for (int i = 0; i < NumAges; i++ ) {
            arrayTextInfo[i].SetActive(false);
         }
		 // Activate the one we need
		 arrayTextInfo[age-1].SetActive(true);
	}
}
