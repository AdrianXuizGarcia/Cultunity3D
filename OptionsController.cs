using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class OptionsController : MonoBehaviour
{

	private bool CCAudio;
	private bool BackgroundMusic;
	public GameObject audioBackground; // for playing background sounds 
	public GameObject audioBackground2; // for playing background sounds 
	public GameObject objectLang;
	public GameObject optionsUI;
	private GameObject FPC;
	
	private bool optionsMenuIsActive;
	private Dropdown buttonLang;
	private GameObject[] audiosLang;
	private Lang LanguageController;
    private string currentLang = "Español";
	
	private const string LangPath = "CC/lang";
	
	private bool noPressKeyYet = false;
	private float decay;
	private const float DecayImage = 0.2f;
 
    public void OnEnable()
    {        
		//LanguageController = new Lang(Path.Combine(Application.dataPath, LangPath), currentLang, false);
		LanguageController = new Lang(LangPath, currentLang, false);
    }
    // Start is called before the first frame update
    void Start()
    {
        CCAudio=true;
		BackgroundMusic=true;
		buttonLang = objectLang.GetComponent<Dropdown>();
		audiosLang = GameObject.FindGameObjectsWithTag("AudioLang");
		FPC = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Reset();
        if (Input.GetKey("p") && !optionsMenuIsActive && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Pause();
		}
		if (Input.GetKey("p") && optionsMenuIsActive && !noPressKeyYet)
		{
			decay = DecayImage;
			noPressKeyYet = true;
			Resume();
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
 
	public void ActivateCCAudio()
	{
		CCAudio = !CCAudio;
	}
	
	public bool IsActiveCCAudio()
	{
		return CCAudio;
	}
	
	public void ActivateBackgroundMusic()
	{
		BackgroundMusic = !BackgroundMusic;
		if (!BackgroundMusic){
			audioBackground.GetComponent<AudioSource>().Stop();
			audioBackground2.GetComponent<AudioSource>().Stop();
		} else {
			audioBackground.GetComponent<AudioSource>().Play();
			audioBackground2.GetComponent<AudioSource>().Play();
		}
	}
	
	public bool IsActiveBackgroundMusic()
	{
		return BackgroundMusic;
	}
	
	public Lang GetLangController()
	{
		return LanguageController;
	}
	
	public void ChangeLanguage()
	{
		string newLang = "None"; 
		
		switch (buttonLang.value)
		{
			case 0:
				newLang="Español";
				break;
			case 1:
				newLang="Galego";
				break;
			case 2:
				newLang="English";
				break;
		}
 
		//LanguageController.setLanguage(Path.Combine(Application.dataPath, LangPath), newLang);
		LanguageController.setLanguage(LangPath, newLang);
		currentLang = newLang;
		
		foreach (GameObject audio in audiosLang)
        {
            audio.GetComponent<ChangeAudioLanguage>().UpdateAudio(currentLang);
        }
	}
	
	public string GetCurrentLang()
	{
		return currentLang;
	}
	
	public void Resume()
    {
        // Make the menu UI invisible
        optionsUI.SetActive(false);
		
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().noUpdate=false;

		optionsMenuIsActive = false;
		
        // Resume the game time
        //Time.timeScale = 1f;

		// Turn off Special Mode if activated
		//modeController.deactivateSpecialMode();
		
		//Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;  
			
		// Lock the mouse again
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_MouseLook.m_cursorIsLocked = true;
    }


    public void Pause()
    {
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().m_MouseLook.m_cursorIsLocked = false;
		
		FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().noUpdate=true;
		
        // Make the menu UI visible
        optionsUI.SetActive(true);

		optionsMenuIsActive = true;
		
        // Stop the game time
        //Time.timeScale = 0f;

		//modeController.deactivateSpecialMode();
		}


    public void LoadMenu()
    {
        Debug.Log("LoadMenu");
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("MenuScene");
    }


    public void Quit()
    {
        Debug.Log("Quit");
                // Exit in case it's a deployed application or stop the editor in case it's running under UnityEditor
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit ();
        #endif
    }

}
