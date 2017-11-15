using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour {

    public Text gold;
    private DataScript data = new DataScript();

    public void OpenBank()
    {
        gold.text = data.GetGold().ToString();
    }
    // Use this for initialization
    void Start () {
        gold.text = data.GetGold().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
