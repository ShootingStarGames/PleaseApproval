using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ViewPaperScript : MonoBehaviour {
    public Text Year, Month, Ink;
	public Text dialog_text;
	public Text content_text;
    public Image char_img;
    public Text char_name;
    public CompanyChart chart;
    public GameObject char_obj;
    public GameObject Box_obj;
    public Button SignBtn;
    public EndingScript end = new EndingScript();
    public TutorialScript tuto;
    public Event.EventScript EventScript;
    public GameObject[] event_icon;
    public SkillScript Skill;

    private Sprite sign_img;
    private DataScript data;
    private Sprite[] charlist;
    private Paper.PaperContentList paper;
    private float posX; // 결재서류 위치.
    private float posY;
    private bool isMoving = false;

    IEnumerator PapertoChar() // 결재서류를 사람얼굴로 옮김.
    {
        Box_obj.transform.position = new Vector3(Box_obj.transform.position.x, Box_obj.transform.position.y, 20);
        isMoving = true;
        float currentX = this.transform.position.x;
        float currentY = this.transform.position.y;
        float x = currentX - char_obj.transform.position.x;
        float y = currentY - char_obj.transform.position.y;
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i <= 30; i++)
        {
            transform.position = new Vector2(currentX - (x*i) / 30, currentY - (y* i) / 30);
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(0.2f);
        transform.position = new Vector2(posX, posY); 
        ViewPaper();
        isMoving = false;
    }

    public bool GetMove()
    {
        return isMoving;
    }
    // 캐릭터 얼굴 
    private void GetCharList()
    {
        charlist = new Sprite[9];
        for (int i = 0; i < 9; i++)
        {
            charlist[i] = Resources.Load("Images/char/" + i, typeof(Sprite)) as Sprite;
        }
        sign_img = Resources.Load("Images/sign_paper1", typeof(Sprite)) as Sprite;
    }

    public void initDay()
    {
        int day = data.GetDay();
        Year.text = (1993 + day / 12).ToString();
        Month.text = (day % 12+1).ToString();
    }

    public void SetDay()
    {
        int i = data.GetInk();
        //data.SetInk(i - 1);// 잉크 줄이기
        data.SetDay();
        int day = data.GetDay();
        Year.text = (1993 + day / 12).ToString();
        Month.text = (day % 12+1).ToString();
        Ink.text = data.GetInk().ToString();

    }
    // 보여줌
    public void ViewPaper(){
		paper.ResetPaperContentList ();
		dialog_text.text = paper.getDialog ();
		content_text.text = paper.getContent ();
        char_img.sprite = charlist[paper.getCharIdx()]; // 캐릭 이미지
        char_name.text = paper.getName(); // 캐릭 이름
        SignBtn.interactable = true; // 버튼 누를수 있음
        SignBtn.image.sprite = sign_img; // 버튼 이미지 초기화
    }
       
    //엔딩체크
    bool CheckEnding()
    {
        data.ResetCooltime();
        Skill.Skill_button();
        SetDay();
        int[] data_arr = { 0, 0, 0, 0, 0 };//돈,직원,업무량,점유율
        bool[] end_arr = { false, false, false, false, false };

        data_arr[0] = data.GetCurrent(1);
        data_arr[1] = data.GetCurrent(2);
        data_arr[2] = data.GetCurrent(3);
        data_arr[3] = data.GetDomestic();
        data_arr[4] = data.GetOverseas();

        bool end_flag = false;

        for (int i = 0; i < 3; i++)
        {
            if (data_arr[i] <= 0 || data_arr[i] >= 100)
            {
                end_arr[i] = true;
                end_flag = true;
            }
        }

        if (data_arr[3] >= 100) //점유율 확인 국내
        {
            end_arr[3] = true;
            end_flag = true;
        }
        else if (data_arr[4] >= 100) //점유율 확인 해외
        {
            end_arr[4] = true;
            end_flag = true;
        }

        if (end_flag)
        {
            Debug.Log("엔딩");
            end.ShowEnding(end_arr,data_arr);
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckInk()
    {
        if(data.GetInk()==30)
            PlayerPrefs.SetString("Date", System.DateTime.Now.Ticks.ToString());
        if (data.GetInk() > 0)
        {
            return true;
        }
        SignBtn.interactable = true; // 버튼 누를수 있음
        SignBtn.image.sprite = sign_img; // 버튼 이미지 초기화
        return false;
    }

    public void EventOccur_cont() // 지속 이벤트
    {
        int ran;
        ran = Random.RandomRange(0, 8);
        int day = Random.RandomRange(1, 13);
        string[] s = data.GetFlag().Split(' ');
        int[] n = new int[s.Length];
    
        string str = "";
        for (int i = 0; i < s.Length; i++)
        {
            n[i] = System.Int32.Parse(s[i]);
            if (i == ran)
            {
                n[i] = day;
                event_icon[i].SetActive(true);
            }
            str += n[i];
            if(i<s.Length-1)
                str += " ";
            if (n[i] == 0)
                event_icon[i].SetActive(false);
        }
        data.SetFlag(str);
    }

    void Check_EventOccur_cont() // 지속 이벤트 체크
    {
        string[] s = data.GetFlag().Split(' ');
        int[] n = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            n[i] = System.Int32.Parse(s[i]);
            if (n[i] == 0)
                event_icon[i].SetActive(false);
            else
            {
                event_icon[i].SetActive(true);
            }
        }

    }

    void EventOccur() //일시적 이벤트
    {
        if (data.GetDay()==48)
            EventScript.Event(0);
        else if (Month.text=="11")
        {
            int r = Random.Range(1, 3);
            if (r == 1)
                return;
            EventScript.Event(1);
        }
    }

    // 거절
    public void FalsePaper(){
        if (!CheckInk())
            return;

        int emp = paper.getFalseEmp();
        int money = paper.getFalseMoney();
        int proj = paper.getFalseProj();
        int share = paper.getFalseO();
        int Gshare = paper.getFalseG();

        data.SetMonth(); // 1달 추가.

        int month = data.GetMonth();
        Queue<int> M = data.GetMoney();
        int m = data.GetCurrent(1);
        Queue<int> E = data.GetEmployee();
        int e = data.GetCurrent(2);
        Queue<int> P = data.GetProject();
        int p = data.GetCurrent(3);
        EventScript.EventFunction(ref m,ref e,ref p);
        if (month > 6)
        {
            M.Dequeue();
            M.Enqueue(m + money);
            E.Dequeue();
            E.Enqueue(e + emp);
            P.Dequeue();
            P.Enqueue(p + proj);
        }
        else
        {
            M.Enqueue(m + money);
            E.Enqueue(e + emp);
            P.Enqueue(p + proj);
        }
        data.SetMoney(M);
        data.SetEmployee(E);
        data.SetProject(P);
        chart.SetChart(share , Gshare);
        ViewPaper();
        transform.position = new Vector2(posX, posY);

        AudioScript.Instance().playReject();
        EventOccur();
        Check_EventOccur_cont();
        CheckEnding();
    }
	// 승인
	public void TruePaper(){
        if (!CheckInk())
            return;
        int money = paper.getTrueMoney(); // money 증가값
        int emp = paper.getTrueEmp(); // emp 증가값
        int proj = paper.getTrueProj(); // proj 증가값
        int share = paper.getTrueO(); // share 증가값
        int Gshare = paper.getTrueG(); 

        data.SetMonth(); // 1달 추가.
        int month = data.GetMonth();
        Queue<int> M = data.GetMoney();
        int m = data.GetCurrent(1);
        Queue<int> E = data.GetEmployee();
        int e = data.GetCurrent(2);
        Queue<int> P = data.GetProject();
        int p = data.GetCurrent(3);

        EventScript.EventFunction(ref m, ref e, ref p);

        if (month > 6)
        {
            M.Dequeue();
            M.Enqueue(m + money);
            E.Dequeue();
            E.Enqueue(e + emp);
            P.Dequeue();
            P.Enqueue(p + proj);
        }
        else
        {
            M.Enqueue(m + money);
            E.Enqueue(e + emp);
            P.Enqueue(p + proj);
        }
        data.SetMoney(M);
        data.SetEmployee(E);
        data.SetProject(P);
        chart.SetChart(share, Gshare);
        StartCoroutine(PapertoChar());
        
        AudioScript.Instance().playSign();
        EventOccur();
        Check_EventOccur_cont();
        CheckEnding();
        if (paper.getCharIdx() == 8)
        {
            EventOccur_cont();
        }
    }

    public void SetValuePaper(int mon,int emp,int pro)
    {

        data.SetMonth(); // 1달 추가.
        int month = data.GetMonth();
        Queue<int> M = data.GetMoney();
        int m = data.GetCurrent(1);
        Queue<int> E = data.GetEmployee();
        int e = data.GetCurrent(2);
        Queue<int> P = data.GetProject();
        int p = data.GetCurrent(3);

        if (month > 6)
        {
            M.Dequeue();
            M.Enqueue(m + mon);
            E.Dequeue();
            E.Enqueue(e + emp);
            P.Dequeue();
            P.Enqueue(p + pro);
        }
        else
        {
            M.Enqueue(m + mon);
            E.Enqueue(e + emp);
            P.Enqueue(p + pro);
        }
        data.SetMoney(M);
        data.SetEmployee(E);
        data.SetProject(P);
        chart.SetChart(0, 0);

        CheckEnding();
    }

    public void SetChartFunc()
    {
        chart.SetChart(0, 0);
    }


	// Use this for initialization

	void Start ()
    {
        posX = this.transform.position.x;
        posY = this.transform.position.y;
        paper = new Paper.PaperContentList();
        data = new DataScript();
        Ink.text = data.GetInk().ToString();

        GetCharList();
        int GamePlay = data.GetGamePlay();
        if (GamePlay == 0)// 처음플레이 시 튜토리얼.
        {
            tuto.ShowTutorial();
        }
        data.SetGamePlay(2); // 게임중.
        initDay();
        ViewPaper();
        Check_EventOccur_cont();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
