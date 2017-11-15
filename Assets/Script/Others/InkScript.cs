using UnityEngine;
using System.Collections;
using System;

public class InkScript : MonoBehaviour {

    public UnityEngine.UI.Text ink;

    void CheckTime()
    {
        if (PlayerPrefs.GetInt("Ink") >= 30)
            return;
        string date_s = PlayerPrefs.GetString("Date");
        long date = long.Parse(date_s);
        var now = System.DateTime.Now.Ticks;
        double sec = (now- date)/ 10000000.0f;
        if (sec >= 60)
        {
            int n = (int)sec / 60;
            date += 600000000*n;
            PlayerPrefs.SetString("Date", date.ToString());
            int i = PlayerPrefs.GetInt("Ink");
            if (i + n > 30)
                n = 30 - i;
            PlayerPrefs.SetInt("Ink", i + n);
            ink.text = (i + n).ToString();
        }
    } 

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        CheckTime();
    }
}
