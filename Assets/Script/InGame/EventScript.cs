using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Event
{
    public class EventScript : MonoBehaviour
    {

        public Image event_img;
        public Text event_text;
        public CompanyChart chart;

        private DataScript data_s;

        Sprite[] img_arr = new Sprite[2];
        Event.EventClass[] event_c = new Event.EventClass[3];

        void load_IMG()
        {
            for (int i = 0; i < 2; i++)
            {
                string path = "Images/event/event0" + (i + 1);
                img_arr[i] = Resources.Load(path, typeof(Sprite)) as Sprite;
            }
        }

        public void EventFunction(ref int m, ref int e, ref int p) //지속 이벤트
        {
            int m_ran = Random.RandomRange(5, 10);
            int e_ran = Random.RandomRange(5, 10);
            int p_ran = Random.RandomRange(5, 10);
            string[] s = data_s.GetFlag().Split(' ');
            int[] n = new int[s.Length];
            string str = "";
            for (int i = 0; i < s.Length; i++)
            {
                n[i] = System.Int32.Parse(s[i]);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (n[i] != 0)
                {
                    n[i]--;
                    switch (i)
                    {

                        case 0:// 돈 다운 //경제 침체
                            m -= m_ran;
                            break;
                        case 1:// 돈 업 //경기 활성화
                            m += m_ran;
                            break;
                        case 2:// 직업 다운 // 퇴직자 증가
                            e -= e_ran;
                            break;
                        case 3:// 직업 업 // 취업률 증가
                            e += e_ran;
                            break;
                        case 4:// 업무량 다운 //야근 증가
                            p -= p_ran;
                            break;
                        case 5:// 업무량 업 //나태해진 직원들
                            p += p_ran;
                            break;
                        case 6:// 돈 직업 업무량 업 //넘치는 아이디어
                            m += m_ran;
                            e += e_ran;
                            p += p_ran;
                            break;
                        case 7:// 돈 직업 업무량 다운 //천재지변
                            m -= m_ran;
                            e -= e_ran;
                            p -= p_ran;
                            break;
                    }
                }
                str += n[i];
                if(i<s.Length-1)
                    str += " ";
            }
            data_s.SetFlag(str);

        }

        void CreateEvent()
        {   //돈,직원,업무량,국내,해외
            event_c[0] = new Event.EventClass();
            event_c[0].addAll(new int[]{ -10, -10, -10, -10, -10 }, "IMF 외환 위기로 인한 회사 운영에 어려움이 발생했습니다.\n 직원들의 사기와 회사 자금이 줄어듭니다.",img_arr[0]);
            event_c[1] = new Event.EventClass();
            event_c[1].addAll(new int[] { 10, 0, 10, 5, 0 }, "크리스마스로 인해 바빠지겠네요.\n 업무량과 회사 자금이 늘어납니다.", img_arr[1]);
        }

        void ApplyData(int [] data)
        {
            int money = data[0]; // money 증가값
            int emp = data[1]; // emp 증가값
            int proj = data[2]; // proj 증가값
            data_s.SetMonth(); // 1달 추가.
            int month = data_s.GetMonth();
            Queue<int> M = data_s.GetMoney();
            int m = data_s.GetCurrent(1);
            Queue<int> E = data_s.GetEmployee();
            int e = data_s.GetCurrent(2);
            Queue<int> P = data_s.GetProject();
            int p = data_s.GetCurrent(3);

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
            data_s.SetMoney(M);
            data_s.SetEmployee(E);
            data_s.SetProject(P);

            chart.SetChart(data[3], data[4]);
        }
        public void Event(int i) //일시적 이벤트
        {
            event_img.gameObject.SetActive(true);
            event_text.text = event_c[i].getDialog();
            event_img.sprite = event_c[i].getImg();
            ApplyData(event_c[i].getDate());
        }

        // Use this for initialization


        void Start()
        {
            load_IMG();
            CreateEvent();
            data_s = new DataScript();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}