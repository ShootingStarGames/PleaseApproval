using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class NewGameButtonsScript : MonoBehaviour {
	public GameObject StartWindow;
	public GameObject BackWindow;
    DataScript data;
    //public NewGameSetSign newGameSetSignScript;
    public Text CompanyName;
    public Sign SignScript;

	private bool isCorrectCompanyName(string s){
		if (!Regex.IsMatch (s, @"[^a-zA-Z0-9가-힣_]")) {
			if (s.Length != 0)
				return true;
		}
		return false;
	}
	// Really Start Game?? 
	public void StartGame(){
		// CompanyName != null and SetSign
		if (isCorrectCompanyName(CompanyName.text) && SignScript.IsSetSign()) {
			// 확인하는 창 띄움
			StartWindow.SetActive (true);
		} else {
			BackWindow.SetActive (true);
		}
	}

	public void CloseStartWindow(){
		StartWindow.SetActive (false);
	}
	public void CloseBackWindow(){
		BackWindow.SetActive (false);
	}
	// Click Start Button in StartWindow
	// StartGame!!! -> Loding -> Tutorial GOGO
	public void RealStartGame(){
		SignScript.SaveTexture();
        data.ResetData();
        data.SetCompanyName(CompanyName.text);
    }

	// Use this for initialization
	void Start () {
        data = new DataScript();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
