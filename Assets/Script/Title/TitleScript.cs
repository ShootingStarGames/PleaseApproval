using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {

    Sprite[] building_img;
    Sprite[] background_img;
    public Image Building;
    public Image Balloon;
    public Image Background;
    private DataScript data;

    void ChangeBackground()
    {
        int time =System.DateTime.Now.Hour;
        if (time >= 20 || time <= 5)
            Background.sprite = background_img[0];
        else if (time < 20 || time > 12)
            Background.sprite = background_img[2];
        else
            Background.sprite = background_img[1];
    }

    void Buildin_IMG()
    {
        for(int i = 0; i < 8; i++)
        {
            string path = "Images/Title/Building/com0" + (i + 1);
            building_img[i] = Resources.Load(path, typeof(Sprite)) as Sprite;
        }
    }
    void Background_IMG()
    {
        for (int i = 0; i < 3; i++)
        {
            string path = "Images/Title/title" + i;
            background_img[i] = Resources.Load(path, typeof(Sprite)) as Sprite;
        }
    }

    bool flag = false;
    IEnumerator BalloonUpDown()
    {
        while (true)
        { 
            if (flag)
            {
                Balloon.transform.localPosition = new Vector3(0, -80, 0);
                yield return new WaitForSeconds(0.5f);
                flag = false;
            }
            else
            {
                Balloon.transform.localPosition = new Vector3(0,-75, 0);
                yield return new WaitForSeconds(0.5f);
                flag = true;
            }
        }
    }
    public void GameStart()
    {
        if(PlayerPrefs.GetInt("GamePlay")!=2)
            SceneManager.LoadScene("NewGameSetting");
        else
            SceneManager.LoadScene("InGame");
    }
    void SetBuilding()
    {
        int GamePlay = data.GetGamePlay();
        if (GamePlay != 2)
            Building.sprite = building_img[0];
        else
        {
            int share = data.GetDomestic() + data.GetOverseas();
            if (share <= 25)
                Building.sprite = building_img[1];
            else if (share <= 50)
                Building.sprite = building_img[2];
            else if (share <= 75)
                Building.sprite = building_img[3];
            else if (share <= 100)
                Building.sprite = building_img[4];
            else if (share <= 125)
                Building.sprite = building_img[5];
            else if (share <= 150)
                Building.sprite = building_img[6];
            else if (share <= 200)
                Building.sprite = building_img[7];

        }
    }
	// Use this for initialization
	void Start () {
        Screen.SetResolution(1280, 720, false);
        data = new DataScript();
        building_img = new Sprite[8];
        background_img = new Sprite[3];
        Buildin_IMG();//건물 이미지
        Background_IMG();//배경 이미지
        ChangeBackground();//시간에 따라 다르게.
        SetBuilding();//건물 변경
        StartCoroutine(BalloonUpDown());//말풍선
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
