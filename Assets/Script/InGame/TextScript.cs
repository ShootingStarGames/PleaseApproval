using UnityEngine;
using System.Collections;

public class TextScript : MonoBehaviour {
    public UnityEngine.UI.Text CompanyName;
    DataScript data = new DataScript();
	// Use this for initialization
	void Start () {
        CompanyName.text = data.GetCompanyName();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
