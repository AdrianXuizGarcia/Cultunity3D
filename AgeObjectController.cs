using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeObjectController : MonoBehaviour
{
	private GameObject ModeController;
	private GameObject AgeController;
	private MeshCollider mesh;

	private const int NumAges = 7; // How many Ages + 1 (for the special mode)
	[HideInInspector]
	public bool[] arrayAges = new bool[NumAges]; // array that contains all ages (define its size on the constant NumAges)
	[Header("Ages you want the object to appear")]
	public bool age1;
	public bool age2;
	public bool age3;
	public bool age4;
	public bool age5;
	public bool age6;
	public bool specialMode;
	
	[Header("If toogle on, affects the first child")]
	public bool objectIsAButton;
	
	private bool focusOnObject;
	private bool actualFocus;
	
	private GameObject childObject;

	[Header("If you want especific materials")]
	public Material SpecialModeMaterial;
	public Material FocusMaterial;
	public Material ActualFocusMaterial;
	private Material originalMat;
	
	void Start() {
		arrayAges[0]=specialMode;
		arrayAges[1]=age1;
		arrayAges[2]=age2;
		arrayAges[3]=age3;
		arrayAges[4]=age4;
		arrayAges[5]=age5;
		arrayAges[6]=age6;
		originalMat = gameObject.GetComponent<Renderer>().material;
		mesh = gameObject.GetComponent<MeshCollider>();
		ModeController = GameObject.FindWithTag("ModeController");
        AgeController = GameObject.FindWithTag("AgeController");
		
		if ((gameObject.transform.childCount!=0) && objectIsAButton)
			childObject = gameObject.transform.GetChild(0).gameObject;
		if (SpecialModeMaterial == null) 
			SpecialModeMaterial = Resources.Load("Materials/SpecialMode", typeof(Material)) as Material;
		if (FocusMaterial == null) 
			FocusMaterial = Resources.Load("Materials/Focus", typeof(Material)) as Material;
		if (ActualFocusMaterial == null) 
			ActualFocusMaterial = Resources.Load("Materials/ActualFocus", typeof(Material)) as Material;
    }
	
    // Update is called once per frame
    void Update()
    {
		// 1º case: we have to focus on the item
		if (actualFocus)
		{
			gameObject.GetComponent<Renderer>().material = ActualFocusMaterial;
			//gameObject.GetComponent<Renderer>().enabled = true;
		} else {
			// 2º case: the rest of the focus
			if (focusOnObject)
			{
				gameObject.GetComponent<Renderer>().material = FocusMaterial;
				//gameObject.GetComponent<Renderer>().enabled = true;
			} else {
				// 3º case: we are in special view and the object is set to appear in it
				if (ModeController.GetComponent<ModeController>().specialViewIsActive &&
					arrayAges[0]) 
				{
					if (mesh != null)
						gameObject.GetComponent<MeshCollider>().enabled = false;
					
					gameObject.GetComponent<Renderer>().material = SpecialModeMaterial;
					gameObject.GetComponent<Renderer>().enabled = true;
				} else {
					// 4º case: the actual age match the age of the object, and we are not
					// on special view
					if (!ModeController.GetComponent<ModeController>().specialViewIsActive &&
						arrayAges[AgeController.GetComponent<AgeController>().ActualAge()] )
					{
						if (mesh != null)
							gameObject.GetComponent<MeshCollider>().enabled = true;
						if (childObject!=null) 
							childObject.SetActive(true);
							
						gameObject.GetComponent<Renderer>().material = originalMat;
						gameObject.GetComponent<Renderer>().enabled = true;
					// 5º case: the actual age doesnt match the age of the object, or
					// we are in special view but the object cannot appear
					} else {
						if (mesh != null)
							gameObject.GetComponent<MeshCollider>().enabled = false;
						gameObject.GetComponent<Renderer>().enabled = false;
						if (childObject!=null)
							childObject.SetActive(false);
					}
				}
			}
		}
	}
	
	public void Focus (bool focus)
	{
		focusOnObject = focus;
		//Debug.Log("focus normal");
		//actualFocus = !focus;
	}
	
	public void ActualFocus (bool focus)
	{
		actualFocus = focus;
		//Debug.Log("focus actual");
		//focusOnObject = !focus;
	}
}
