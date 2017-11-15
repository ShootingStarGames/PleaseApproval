using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour {

    private DataScript data = new DataScript();
    public ViewPaperScript View;
    public Button skill_b;
    public Image fade_img;
    public Image Skill_back;
    public Image Controll_back;
    public Slider m_s, e_s, p_s;

    private Sprite[] skill_img;

    void GetSkillImg()
    {
        skill_img = new Sprite[4];
        for (int i = 0; i < 4; i++)
        {
            string path = "Images/skill/skill_background0" + (i + 1);
            skill_img[i] = Resources.Load(path, typeof(Sprite)) as Sprite;
        }
    }

    void ShowImage(int i)
    {
        Skill_back.sprite = skill_img[i];
    }

    private IEnumerator fadeOut()
    {
        for (int i = 0; i < 10; i++)
        {
            fade_img.color = new Vector4(1, 1, 1,(float)i / 10);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(fadeIn());
    }
    private IEnumerator fadeIn()
    {
        for (int i = 0; i <= 10; i++)
        {
            fade_img.color = new Vector4(1, 1, 1, 1- (float)i / 10);
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void Skill_button()
    {
        if(data.GetCooltime()>=12)
            skill_b.interactable = true;
    }

    private void Skill_1()
    {
        StartCoroutine(fadeOut());
        View.SetValuePaper(15,0,0);
    }
    private void Skill_2()
    {
        StartCoroutine(fadeOut());
        View.EventOccur_cont();
    }
    private void Skill_3()
    {
        Controll_back.gameObject.SetActive(true);
    }

    public void Accept()
    {
        View.SetValuePaper((int)((0.5f-m_s.value)*10), (int)((0.5f - e_s.value)*10), (int)((0.5f - p_s.value)*10));
        Controll_back.gameObject.SetActive(false);
    }

    private void Active_skill()
    {
        int op = data.GetCurrentBisu();
        ShowImage(op);
        switch (op)
        {     
            default:
                return;
            case 0:
                return;
            case 1:
                Skill_1();
                break;
            case 2:
                Skill_2();
                break;
            case 3:
                Skill_3();
                break;
        }
        data.SetCooltime();
        skill_b.interactable = false;
    }

    public void ActiveSkill()
    {
        int n = data.GetCooltime();
        Active_skill();
        if (n >= 12)
        {
            Active_skill();
        }
    }
    // Use this for initialization
    void Start () {
        GetSkillImg();
        if (data.GetCooltime() < 12)
            skill_b.interactable = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
