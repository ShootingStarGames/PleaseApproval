using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpDownScript : MonoBehaviour {

    public GameObject b1, b2;
    bool flag;
    IEnumerator ButtonUpDown()
    {
        while (true)
        {
            if (flag)
            {
                b1.transform.localPosition = new Vector3(580, 75, 0);
                b2.transform.localPosition = new Vector3(375.3f, -280, 0);
                yield return new WaitForSeconds(0.5f);
                flag = false;
            }
            else
            {
                b1.transform.localPosition = new Vector3(580, 78, 0);
                b2.transform.localPosition = new Vector3(375.3f, -285, 0);
                yield return new WaitForSeconds(0.5f);
                flag = true;
            }
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(ButtonUpDown());	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
