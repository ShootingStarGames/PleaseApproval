using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

    AudioClip s_sign,s_reject,s_drag;


    static AudioScript _instance = null;

    public static AudioScript Instance()
    {
        return _instance;
    }

    // Use this for initialization
    void Start () {
        s_sign = Resources.Load("Sounds/bookFlip2_up") as AudioClip;
        s_reject = Resources.Load("Sounds/bookPlace3") as AudioClip;
        s_drag = Resources.Load("Sounds/bookOpen") as AudioClip;
        if (_instance == null)
            _instance = this;
    }

    public void playDrag()
    {
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource>().PlayOneShot(s_drag);
    }

    public void playSign()
    {
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource>().PlayOneShot(s_sign);
    }

    public void playReject()
    {
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource>().PlayOneShot(s_reject);

    }
    // Update is called once per frame
}
