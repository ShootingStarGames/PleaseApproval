using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour {

    public AudioSource Sound,Audio;

   
    public void SoundOnOff()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            PlayerPrefs.SetInt("Sound", 0);
            Sound.mute = false;
            Audio.mute = false;
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            Sound.mute = true;
            Audio.mute = true;
        }
    }
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("Sound")==1)
        {
            Sound.mute = true;
            Audio.mute = true;
        }
        else
        {
            Sound.mute = false;
            Audio.mute = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
