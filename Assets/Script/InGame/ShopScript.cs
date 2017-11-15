using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    private DataScript data = new DataScript();
    public Image bisu;
    public Text[] text;
    public BisuScript Bisu;
    private Sprite[] bisu_img;

    void GetBisuImg()
    {
        bisu_img = new Sprite[4];
        for(int i = 0; i < 4; i++)
        {
            string path = "Images/bisu/bisu0" + (i + 1);
            bisu_img[i] = Resources.Load(path, typeof(Sprite)) as Sprite;
        }
    }
    void SetBisuImg()
    {
        int i = data.GetCurrentBisu();
        bisu.sprite = bisu_img[i];
        Bisu.SetBisuText();
    }

    void BuyBisu(int i)
    {
        if (data.GetGold()>=10)
        {
            data.SetGold(-10);
            data.SetBisu(i);
            SetText();
        }
    }

    public void SelectBisu(int i)
    {
        string[] s = data.GetBisu().Split(' ');
        int[] array = new int[s.Length-1];
        for(int n = 0; n < 4; n++)
        {
            array[n] = System.Int32.Parse(s[n]);
        }

        if (array[i] == 1)
        {
            data.SetCurrentBisu(i);
            SetBisuImg();
        }
        else
        {
            BuyBisu(i);
        }
    }
    
    public void Buyink()
    {
        if (data.GetGold() >= 1)
        {
            data.SetGold(-1);
            data.SetInk(data.GetInk()+1);
        }
    }



    void SetText()
    {
        string[] s = data.GetBisu().Split(' ');
        for (int n = 0; n < 4; n++)
        {
            if (s[n] == "1")
            {
                text[n].text = "";
            }
        }
        
    }
    // Use this for initialization
    void Start () {
        GetBisuImg();
        SetBisuImg();
        SetText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
