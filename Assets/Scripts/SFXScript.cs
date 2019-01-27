using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour {

    public static AudioClip gato1, gato2, romrom;
    static AudioSource audioSource;

	// Use this for initialization
	void Start () {
        gato1 = Resources.Load<AudioClip>("gato 1");
        gato2 = Resources.Load<AudioClip>("gato 2");
        romrom = Resources.Load<AudioClip>("romrom");

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound(string sfx)
    {
        switch (sfx)
        {
            case "gato1":
                audioSource.Stop();
                audioSource.PlayOneShot(gato1);
                break;
            case "gato2":
                audioSource.Stop();
                audioSource.PlayOneShot(gato2);
                break;
            case "romrom":
                audioSource.Stop();
                audioSource.PlayOneShot(romrom);
                break;
        }
    }
}
