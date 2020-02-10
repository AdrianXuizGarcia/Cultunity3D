using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextLanguage : MonoBehaviour
{
    private Lang LMan;
	public string textRefFromXml;
	
    // Start is called before the first frame update
    void Start()
    {
        LMan = GameObject.FindWithTag("OptionsController").GetComponent<OptionsController>().GetLangController();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Text>().text = LMan.getString(textRefFromXml);
    }
}
