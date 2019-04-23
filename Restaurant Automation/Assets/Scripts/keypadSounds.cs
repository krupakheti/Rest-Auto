using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypadSounds : MonoBehaviour {
    private AudioSource thisPlayer;
    public AudioClip beep, denied, granted, clear;


	// Use this for initialization
	void Start () {
		thisPlayer = this.gameObject.GetComponent<AudioSource>();
	}
	
	public void playSound(int whichSound) { 
    
       if(whichSound == 1) thisPlayer.PlayOneShot(beep);
       if(whichSound == 2) thisPlayer.PlayOneShot(denied);
       if(whichSound == 3) thisPlayer.PlayOneShot(granted);
       if(whichSound == 4) thisPlayer.PlayOneShot(clear);
    
    }

}
