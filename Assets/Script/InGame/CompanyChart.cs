using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CompanyChart : MonoBehaviour {

    int[] money, project, employee; // 각 수치 배열
    GameObject money_line, project_line, employee_line; // 각 수치 라인 오브젝트
    GameObject[] money_circle, project_circle, employee_circle; // 각 수치 배열
    public CompanyShare Share;
    // Use this for initialization.
    int m; // 달수
    void LoadPrefabs()
    {
        money_circle = new GameObject[7];
        project_circle = new GameObject[7];
        employee_circle = new GameObject[7];

        GameObject prefab = Resources.Load("Prefabs/line") as GameObject;
        GameObject prefab_circle = Resources.Load("Prefabs/circle") as GameObject;
        money_line = MonoBehaviour.Instantiate(prefab) as GameObject;
        project_line = MonoBehaviour.Instantiate(prefab) as GameObject;
        employee_line = MonoBehaviour.Instantiate(prefab) as GameObject;
        // 인스턴스생성
        money_line.transform.parent = this.transform;
        project_line.transform.parent = this.transform;
        employee_line.transform.parent = this.transform;
        money_line.transform.localPosition = new Vector3(50, 50, 0);
        project_line.transform.localPosition = new Vector3(50, 50, 0);
        employee_line.transform.localPosition = new Vector3(50, 50, 0);
        // 부모객체 설정
        money_line.GetComponent<UILineRenderer>().color = Color.yellow;
        project_line.GetComponent<UILineRenderer>().color = Color.red;
        employee_line.GetComponent<UILineRenderer>().color = Color.green;
        for (int i=0;i<6;i++)
        {           
            money_circle[i] = MonoBehaviour.Instantiate(prefab_circle) as GameObject;
            project_circle[i] = MonoBehaviour.Instantiate(prefab_circle) as GameObject;
            employee_circle[i] = MonoBehaviour.Instantiate(prefab_circle) as GameObject;
            // 서클 이미지 인스턴스           
            money_circle[i].transform.parent = this.transform;
            project_circle[i].transform.parent = this.transform;
            employee_circle[i].transform.parent = this.transform;
            // 부모객체 설정
            money_circle[i].GetComponent<Image>().color = Color.yellow;
            project_circle[i].GetComponent<Image>().color = Color.red;
            employee_circle[i].GetComponent<Image>().color = Color.green;
            // 색 설정
        }
        
        money_circle[6] = MonoBehaviour.Instantiate(prefab_circle) as GameObject;
        project_circle[6] = MonoBehaviour.Instantiate(prefab_circle) as GameObject;
        employee_circle[6] = MonoBehaviour.Instantiate(prefab_circle) as GameObject;
        money_circle[6].transform.parent = this.transform;
        project_circle[6].transform.parent = this.transform;
        employee_circle[6].transform.parent = this.transform;
        money_circle[6].GetComponent<Image>().color = Color.yellow;
        project_circle[6].GetComponent<Image>().color = Color.red;
        employee_circle[6].GetComponent<Image>().color = Color.green;
    }

    void DrawLine(int n)
    {
        int k=1;
        for (int i = 0; i <= 6; i++) {
            k = i;
            if (m <= k)
                k = m;
            money_circle[k].GetComponent<Transform>().localPosition = new Vector3(k*35, money[k]*0.8f, 0);
            project_circle[k].GetComponent<Transform>().localPosition = new Vector3(k*35, project[k]*0.8f, 0);
            employee_circle[k].GetComponent<Transform>().localPosition = new Vector3(k*35, employee[k]*0.8f, 0);

            money_line.GetComponent<UILineRenderer>().Points.SetValue(new Vector2(k*35,money[k]*0.8f),i);
            project_line.GetComponent<UILineRenderer>().Points.SetValue(new Vector2(k*35,project[k]*0.8f), i);
            employee_line.GetComponent<UILineRenderer>().Points.SetValue(new Vector2(k*35,employee[k]*0.8f), i);
        };

        money_circle[n].GetComponent<Transform>().localPosition = new Vector3(k * 35, money[k]*0.8f, 0);
        project_circle[n].GetComponent<Transform>().localPosition = new Vector3(k * 35, project[k]*0.8f, 0);
        employee_circle[n].GetComponent<Transform>().localPosition = new Vector3(k * 35, employee[k]*0.8f, 0);
        money_line.SetActive(false); // 수치는 입력이 되는데 그림으로 안보여서 한번 껏다킴
        money_line.SetActive(true);
        project_line.SetActive(false);
        project_line.SetActive(true);
        employee_line.SetActive(false);
        employee_line.SetActive(true);
    }
    void LoadChartBoard()
    {
        int length = PlayerPrefs.GetInt("Month");

        money = new int[7];
        project = new int[7];
        employee = new int[7];
        string[] Money_array = PlayerPrefs.GetString("Money").Split(' ');
        string[] Project_array = PlayerPrefs.GetString("Project").Split(' ');
        string[] Employee_array = PlayerPrefs.GetString("Employee").Split(' ');
       
        for (int i=0;i<= 6; i++)
        {
            int k = i;
            if(length< i)
            {
                k = length;
            }
            money[i] = System.Int32.Parse(Money_array[k]);
            project[i] = System.Int32.Parse(Project_array[k]);
            employee[i] = System.Int32.Parse(Employee_array[k]);
            money_circle[k].SetActive(true);
            project_circle[k].SetActive(true);
            employee_circle[k].SetActive(true);
        }
    }

    public void SetChart(int i, int j)
    {
        LoadChartBoard();
        m = PlayerPrefs.GetInt("Month");
        if (m > 6)
            m = 6;
        DrawLine(m);
        Share.SetShare(i,j);
    }

    void Start () {
        LoadPrefabs();
        LoadChartBoard();
        m = PlayerPrefs.GetInt("Month");
        if (m > 6)
            m = 6;
        DrawLine(m);
        Share.SetShare(0,0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
