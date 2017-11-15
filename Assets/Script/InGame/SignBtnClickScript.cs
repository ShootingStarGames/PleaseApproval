using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SignBtnClickScript : MonoBehaviour {
	public Image SignImg;
    public Button SignBtn;
    public ViewPaperScript View;

	public void SignCheck(){
        // 승인
        string path = Application.persistentDataPath + "/Sign.png";
        var bytes = System.IO.File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(240, 120, TextureFormat.ARGB32, false);
        texture.LoadImage(bytes);
        Sprite signImg = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
		SignImg.sprite = signImg;
        SignBtn.interactable = false;
        View.TruePaper();
    }

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
