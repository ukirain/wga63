using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public AudioSource AS;
    public AudioSource audioSource;
    public AudioSource Music;
    public AudioClip klik;
    public AudioClip town;
    public AudioClip move;
    public AudioClip ev;
    public AudioClip gameover;
    public AudioClip campe;
    public AudioClip siren;
    public AudioClip ship;
    public AudioClip windows;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("CLICK");
            GetComponent<AudioSource>().PlayOneShot(klik);
        }
	}

    public void otherTown() {
        Debug.Log("audio otherTown");
        Music.Pause();
        AS.Pause();
        audioSource.clip = town;
        audioSource.Play();
    }

    public void movement() {
        AS.Pause();
        Music.Pause();
        audioSource.clip = move;
        audioSource.Play();
    }

    public void music() {
        AS.Pause();
        AS.clip = windows;
        Music.Play();
    }

    public void musicPause() {
        Music.Pause();
    }

    public void evente() {
        //Music.Pause();
        GetComponent<AudioSource>().PlayOneShot(ev);
        //Music.Play();
    }

    public void gg() {
        GetComponent<AudioSource>().PlayOneShot(gameover);
    }


    public void campain() {
        GetComponent<AudioSource>().PlayOneShot(campe);
    }

    public void sirena() {
        GetComponent<AudioSource>().PlayOneShot(siren);
    }

    public void shipy() {
        Music.Pause();
        AS.loop = true;
        AS.clip = ship;
        AS.Play();
    }
}
