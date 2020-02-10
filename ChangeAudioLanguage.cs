using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudioLanguage : MonoBehaviour
{
    private GameObject buttonLang;
	private AudioSource audio;
	public AudioClip language1;
	public AudioClip language2;
	public AudioClip language3;

	void Start(){
	    audio = GetComponent<AudioSource>();
	}
	
    public void UpdateAudio(string newLang)
    {
		switch (newLang)
			{
				case "Español":
				audio.clip = language1;
				break;
				case "Galego":
				audio.clip = language2;
				break;
				case "English":
				audio.clip = language3;
				break;
		}
    }
}
