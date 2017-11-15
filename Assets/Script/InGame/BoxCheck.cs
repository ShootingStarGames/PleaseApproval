using UnityEngine;
using System.Collections;

public class BoxCheck : MonoBehaviour {

    public Transform parentpos;
    public ViewPaperScript view;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "char")
        {
            view.FalsePaper();
        };
    }
    // Use this for initialization
    void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        transform.position = parentpos.position;
	}
}
