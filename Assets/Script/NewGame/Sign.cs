using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Sign : MonoBehaviour {

    public Camera Camera;
    public GameObject Parent;

    RenderTexture renderTexture;
    GameObject prefab;
    GameObject trail;
    bool isSign = false;
    bool isTouch=false, onScreen = false;
	// Use this for initialization
	void Start () {
        prefab = Resources.Load("Prefabs/Trail") as GameObject;
        renderTexture = new RenderTexture((int)240, (int)120, 0, RenderTextureFormat.ARGB32);
        Camera.targetTexture = renderTexture;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && onScreen)
        {
            isTouch = true;
            trail = MonoBehaviour.Instantiate(prefab) as GameObject;
            trail.transform.parent = Parent.transform;
            isSign = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }

        if (isTouch && onScreen)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
            trail.GetComponent<Transform>().position = mousePos;
        }	
	}

    public bool IsSetSign()
    {
        return isSign;
    }
    public void OnScreen()
    {
        onScreen = true;
    }
    public void OffScreen()
    {
        onScreen = false;
        isTouch = false;
    }

    public void CleanSign()
    {
        foreach (Transform t in Parent.GetComponent<Transform>())
        {
            Destroy(t.gameObject);
        }
        isSign = false;
    }

    public void SaveTexture()
    {
        
        Texture2D texture2D = getTexture2DFromRenderTexture(renderTexture);
        string path = Application.persistentDataPath + "/Sign.png";
        byte[] bytes = texture2D.EncodeToPNG();
        if (File.Exists(path))
            File.Delete(path);
        File.WriteAllBytes(path, bytes);

        Parent.SetActive(false);
    }

    public Texture2D getTexture2DFromRenderTexture(RenderTexture rTex)
    {
        Texture2D texture2D = new Texture2D(rTex.width, rTex.height);
        RenderTexture.active = rTex;
        texture2D.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        Camera.targetTexture = null;
        RenderTexture.active = null;
        texture2D.Apply();
        return texture2D;
    }
    

}
