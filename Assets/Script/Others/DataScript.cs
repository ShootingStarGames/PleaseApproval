using UnityEngine;
using System.Collections.Generic;

public class DataScript : MonoBehaviour {
    
    public void ResetData()
    {
        PlayerPrefs.SetString("Money", "50 "); // 돈
        PlayerPrefs.SetString("Employee", "50 "); // 직원
        PlayerPrefs.SetString("Project", "50 "); // 엄무량
        PlayerPrefs.SetInt("Domestic", 0); // 국내 점유율
        PlayerPrefs.SetInt("Overseas", 0); // 해외 점유율
        PlayerPrefs.SetInt("Month", 0);// 개월 수.   
        PlayerPrefs.SetInt("Day", 0);// 날짜 수.  
        PlayerPrefs.SetString("Flag", "0 0 0 0 0 0 0 0"); // 플래그
        PlayerPrefs.SetInt("Cooltime", 12);
    }

    public string GetFlag()
    {
        return PlayerPrefs.GetString("Flag");
    }
    public void SetFlag(string s)
    {
        PlayerPrefs.SetString("Flag", s);
    }
    public void SetGamePlay(int i)
    {
        PlayerPrefs.SetInt("GamePlay",i);
    }
    public int GetGamePlay()
    {
        return PlayerPrefs.GetInt("GamePlay");
    }

    public void SetDay()
    {
        int i = GetDay();
        PlayerPrefs.SetInt("Day",i+1);
    }
    public int GetDay()
    {
        return PlayerPrefs.GetInt("Day");
    }
    public void SetCompanyName(string s)
    {
        PlayerPrefs.SetString("CompanyName", s);
    }
    public string GetCompanyName()
    {
        return PlayerPrefs.GetString("CompanyName");
    }

    private Queue<int> StringtoQueue(string s)
    {
        Queue<int> queue = new Queue<int>();
        string[] s_array = s.Split(' ');
        for(int i = 0; i < s_array.Length-1; i++)
        {
            queue.Enqueue(System.Int32.Parse(s_array[i]));
        }
        return queue;
    }

    public int GetCurrent(int op)
    {
        string[] array;
        switch (op) {
            case 1:
                array = PlayerPrefs.GetString("Money").Split(' ');
                break;
            case 2:
                array = PlayerPrefs.GetString("Employee").Split(' ');
                break;
            case 3:
                array = PlayerPrefs.GetString("Project").Split(' ');
                break;
            default:
                array = PlayerPrefs.GetString("Money").Split(' ');
                break;
        }
        string s = array[array.Length-2];
        return System.Int32.Parse(s);
    }

    public Queue<int> GetMoney()
    {
        return StringtoQueue(PlayerPrefs.GetString("Money"));
    }
    public Queue<int> GetEmployee()
    {
        return StringtoQueue(PlayerPrefs.GetString("Employee"));
    }
    public Queue<int> GetProject()
    {
        return StringtoQueue(PlayerPrefs.GetString("Project"));
    }

    public int GetMonth()
    {
        return PlayerPrefs.GetInt("Month");
    }


    public void SetDomestic(int sh)
    {
        if (sh + GetDomestic() <= 0)
        {
            PlayerPrefs.SetInt("Domestic", 0);
        }
        else {
            PlayerPrefs.SetInt("Domestic", sh + GetDomestic());
        }
    }
    public int GetDomestic()
    {
        return PlayerPrefs.GetInt("Domestic");
    }
    public void SetOverseas(int sh)
    {
        if (sh + GetOverseas() <= 0)
        {
            PlayerPrefs.SetInt("Overseas", 0);
        }
        else {
            PlayerPrefs.SetInt("Overseas", sh + GetOverseas());
        }
    }
    public int GetOverseas()
    {
        return PlayerPrefs.GetInt("Overseas");
    }

    public void SetMoney(Queue<int> money){
		string s = "";
        int j = PlayerPrefs.GetInt("Month");
        if (j > 6)
            j = 6;
		for (int i = 0; i <= j; i++) {
			int m = money.Dequeue ();
			s = s + m.ToString () + " ";
		}
        PlayerPrefs.SetString("Money", s);
	}
	public void SetProject(Queue<int> project){
		string s = "";
        int j = PlayerPrefs.GetInt("Month");
        if (j > 6)
            j = 6;
        for (int i = 0; i <= j; i++) {
			int m = project.Dequeue ();
			s = s + m.ToString () + " ";
		}
        PlayerPrefs.SetString("Project", s);
    }
	public void SetEmployee(Queue<int> employee){
		string s = "";
        int j = PlayerPrefs.GetInt("Month");
        if (j > 6)
            j = 6;
        for (int i = 0; i <= j; i++) {
			int m = employee.Dequeue ();
			s = s + m.ToString () + " ";
		}
        PlayerPrefs.SetString("Employee", s);
    }
    public void SetMonth()
    {
        int mon = PlayerPrefs.GetInt("Month");
        if (mon <= 6)
            PlayerPrefs.SetInt("Month", ++mon);
    }
    public void SetInk(int n)
    {
        PlayerPrefs.SetInt("Ink", n);
    }

    public int GetInk()
    {
        return PlayerPrefs.GetInt("Ink");
    }
    public string GetEnd()
    {
        return PlayerPrefs.GetString("End");
    }
    public void SetEnd(string s)
    {
        PlayerPrefs.SetString("End", s);
    }
    public int GetGold()
    {
        return PlayerPrefs.GetInt("Gold");
    }
    public void SetGold(int i)
    {
        PlayerPrefs.SetInt("Gold", GetGold() + i);
    }

    public int GetCurrentBisu()
    {
        return PlayerPrefs.GetInt("CurrentBisu");
    }
    public void SetCurrentBisu(int i)
    {
        PlayerPrefs.SetInt("CurrentBisu", i);
    }

    public string GetBisu()
    {
        return PlayerPrefs.GetString("Bisu");
    }
    public void SetBisu(int n)
    {
        string[] s = GetBisu().Split(' ');
        int []array = new int[s.Length];
        for(int i = 0; i < 4; i++)
        {
            array[i] = System.Int32.Parse(s[i]);
        }
        array[n] = 1;
        string str = "";
        for(int i = 0; i < 4; i++)
        {
            str += array[i];
            str += " ";
        }
        PlayerPrefs.SetString("Bisu", str);
    }

    public int GetCooltime()
    {
        return PlayerPrefs.GetInt("Cooltime");
    }
    public void SetCooltime()
    {
        PlayerPrefs.SetInt("Cooltime", 0);
    }
    public void ResetCooltime()
    {
        PlayerPrefs.SetInt("Cooltime", GetCooltime()+1);
    }
    // Use this for initialization
    void Start () {
        if (!PlayerPrefs.HasKey("GamePlay"))
        {
            PlayerPrefs.SetInt("Gold", 0); // 비자금
            PlayerPrefs.SetInt("Ink", 30); // 잉크
            PlayerPrefs.SetInt("Gameplay", 0);//0 첫 플레이, 1 새로 시작, 2 플레이 중
            PlayerPrefs.SetInt("Sound", 0);//0 온 1 오프
            PlayerPrefs.SetString("Bisu", "1 0 0 0 ");
            PlayerPrefs.SetInt("CurrentBisu", 1);
            PlayerPrefs.SetString("End", "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ");
        }
        if (PlayerPrefs.GetInt("GamePlay") != 2)
            ResetData();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
