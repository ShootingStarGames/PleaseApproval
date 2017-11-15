using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class NewGameSetSign : MonoBehaviour {
    public Texture2D texture;
    public ScrollRect scroll;

    private bool isTouch = false;
	private bool isSetSign = false;

    private void openPen() {
        scroll.vertical = false;
    }
    private void closePen() {
        scroll.vertical = true;
    }

    public void ClickPen() {
        if (scroll.vertical)
        {
            openPen();
        }
        else {
            closePen();
        }
    }

    private void clearTexture() {
        for (int i = 0; i < 80; i++) {
            for (int j = 0; j < 40; j++) {
                texture.SetPixel(i, j, Color.clear);
            }
            texture.Apply();
        }
    } 

	public void ClearSign(){
		isSetSign = false;
		clearTexture ();
	}

	public bool IsSetSign(){
		return isSetSign;
	}

	public void SaveTextureToPNG(){
		byte[] bytes = texture.EncodeToPNG();
		// For testing purposes, also write to a file in the project folder
		// save File
		string path = Application.dataPath + "/Sign.png";

		if (File.Exists (path))
			File.Delete (path);
		File.WriteAllBytes (path, bytes);
		Debug.Log (path);
	}
    // Use this for initialization
    void Start () {
        this.GetComponent<Image>().material.mainTexture = texture;
        // clear
        clearTexture();
    }
	
	// Update is called once per frame
	void Update () {
#if UNITY_ANDROID
//        if (Input.GetMouseButtonDown(0)) {
//            isTouch = true;
//        }
//        if (Input.GetMouseButtonUp(0)) {
//            isTouch = false;
//        }

        if (!scroll.vertical && Input.touchCount>0) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( new Vector3(Input.touches[0].position.x, Camera.main.pixelHeight-Input.touches[0].position.y, Camera.main.nearClipPlane) ) * 6;
            Vector3 transformPos = Camera.main.ScreenToWorldPoint( new Vector3(this.transform.position.x, Camera.main.pixelHeight-this.transform.position.y, Camera.main.nearClipPlane) ) * 6;

//            Debug.Log(transformPos - worldPos);

            Vector2 pos = transformPos-worldPos;
            pos.x = 30-(pos.x + 15);
            pos.y = (pos.y + 15);
            //            Debug.Log("x:"+(pos.x+60) + " y:"+(pos.y+60));

            if (0 <= pos.x && pos.x <= 30 && 0 <= pos.y && pos.y <= 30)
            {
                texture.SetPixel((int)pos.x, (int)pos.y, Color.black);
                texture.Apply();
            }
            //            Debug.Log();
        }
#elif UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0)) {
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            isTouch = false;
        }

        //if (!scroll.vertical && isTouch) {
		if(isTouch){
            Vector3 worldPos = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Camera.main.pixelHeight-Input.mousePosition.y, Camera.main.nearClipPlane) ) * 6;
            Vector3 transformPos = Camera.main.ScreenToWorldPoint( new Vector3(this.transform.position.x, Camera.main.pixelHeight-this.transform.position.y, Camera.main.nearClipPlane) ) * 6;

            Debug.Log(transformPos - worldPos);

            Vector2 pos = transformPos-worldPos;
			pos.x = -(pos.x-10)*4;
			pos.y = (pos.y+5)*4;
			//pos.x = 80-(pos.x + 40);
            //pos.y = (pos.y + 20);
            Debug.Log("x:"+(pos.x+0) + " y:"+(pos.y+0));

			if(pos.x<0 || pos.x>80 || pos.y<0 || pos.y>40)
				return;
			
//			pos.x = 0; pos.y = 0;
			texture.SetPixel((int)pos.x, (int)pos.y, Color.black);
            texture.Apply();
			isSetSign = true;
            //            Debug.Log();
        }
        
#endif
    }
}
