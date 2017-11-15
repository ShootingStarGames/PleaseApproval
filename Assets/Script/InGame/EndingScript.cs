using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour {
    public GameObject End_obj;
    public Text End_t;
    private DataScript data = new DataScript();
    private Sprite[] end_img;
    private int[] end_array;

    private string[] end_str = { "회사가 부도가 났습니다.","직원이 아무도 없는데 회사가 돌아갈 까요?","일이 하나도 없네요.\n회사라고 하기도 그렇네요 망해버렸습니다.",
        "많은 돈을 벌었으나 믿었던 친구에게 배신당했습니다.","노조가 파업에 들어갔습니다.","일이 너무 많아서 과로사했습니다.",
        "돈도 없고 직원도 없고 회사가 돌아가겠어요?","돈도 없는데 일도 없고 오늘은 파산신청하러 가야겠네요.","직원이 많은데 월급을 반년동안 지급하지 못했습니다.\n 퇴근길에 습격을 당해 죽었어요.","오랜만에 일이 넘치네요!\n빛을 갚으려고 열심히 일하다 과로사했습니다.",
        "그 많은 돈으로 직원좀 신경써 주지 그랬어요.","돈은 많은데 일거리가 없네요. 돈이 많다고 자만하면 안되죠.\n금방 경쟁사한테 추월 당할 걸요?","돈도 많고 직원도 많고!\n근데 그에 비해 일이 없네요.","돈이 이렇게 많은데 좀 쉬게 해주시지..\n직원 과로사로 인해 회사 이미지가 망가져 망했습니다.",
        "돈도 직원도 할 일도 없네요.\n다시 시작하는게 빠르겠어요.","돈도 직원도 없는데 일만 받아서 어따 쓸려고 그래요.","가진건 직원밖에 없네요.차라리 다른 회사 밑에 들어가는게 어때요?","직원도 많고 일도 많으니까 금방 돈을 벌겠어요! 임금체불만 없다면요.",
        "그래도 돈은 있으니 새로 시작하는게 어때요?","남아도는 돈으로 직원을 뽑지 그래요? 일이 너무 많은데..","회사에 돈도 많고 직원도 많고 일은 적고 신의 직장이네요!\n근데 일이 없네요 다 거품이었나봐요.","돈도 많고 일도 많고 직원도 많고 금방 회사가 크겠네요!\n다음날 대기업들의 담합에 의해 망했습니다.",
        "직원도 없고 일도 없고 그냥 다시 시작하세요.","직원도 없는데 이 많은 일을 혼자 다하시려고?",
        "직원은 많은데 일이 없네요.\n의욕만 가지고 사업을 할 순 없죠.","직원도 많고 업무량도 많은데 뭐가 문제야?\n다음날 경쟁사에 회사 기밀이 유출되어 망했습니다."
    };
    // 돈down 0 // 직원down 1 // 업무량down 2
    // 돈up 3 // 직원up 4 // 업무량up 5

    // 돈down,직원down 6 // 돈down,업무량down 7 // 돈down,직원up 8 // 돈down,업무량up 9
    // 돈up,직원down 10 // 돈up,업무량down 11 // 돈up,직원up 12 // 돈up,업무량up 13
    
    // 돈down,직원down,업무량down 14 // 돈down,직원down,업무량up 15 // 돈down,직원up,업무량down 16 // 돈down,직원up,업무량up 17
    // 돈up,직원down,업무량down 18 // 돈up,직원down,업무량up 19 // 돈up,직원up,업무량down 20 // 돈up,직원up,업무량up 21
        
    // 직원down,업무량down 22 // 직원down,업무량up 23
    // 직원up,업무량down 24 // 직원up,업무량up 25


    void Load_end()
    {
        string[] s = data.GetEnd().Split(' ');
        end_array = new int[s.Length];
        for (int i = 0; i < 26; i++)
        {
            end_array[i] = System.Int32.Parse(s[i]);
        }
    }

    void Load_img()
    {
        end_img = new Sprite[2];
        for (int i = 0; i < 2; i++)
        {
            end_img[i] = Resources.Load("Images/ending/end" + i, typeof(Sprite)) as Sprite;
        }
    }

    IEnumerator Fade_ENDING(int op)
    {
        End_obj.GetComponent<Image>().sprite = end_img[op];
        for (int i = 0; i <= 20; i++)
        {
            End_obj.GetComponent<Image>().color = new Vector4(0.5f, 0.5f, 0.5f, (float)i / 20);
            yield return new WaitForSeconds(0.05f);
        }
        End_t.gameObject.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ShowEnding(bool [] end_arr,int [] data_arr)
    {
        int end_scene = 1;//엔딩 화면
        int end_flag = 0;
        string s = "";
        End_obj.SetActive(true);
        if (end_arr[0]) // 돈 플래그
        {
            if (end_arr[1]) // 돈 + 직원 플래그
            {
                if (end_arr[2]) // 돈 + 직원 +업무량 플래그
                {
                    if (data_arr[0] >= 100) //돈이 +
                    {
                        if (data_arr[1] >= 100) // 직원 +
                        {
                            if (data_arr[2] >= 100) //업무량 +
                            {
                                end_flag = 21;
                            }
                            else // 업무량 -
                            {
                                end_flag = 20;
                            }
                        }
                        else // 직원 -
                        {
                            if (data_arr[2] >= 100) // 업무량 +
                            {
                                end_flag = 19;
                            }
                            else // 업무량 -
                            {
                                end_flag = 18;
                            }
                        }
                    }
                    else //돈이 -
                    {
                        if (data_arr[1] >= 100) //직원 +
                        {
                            if (data_arr[2] >= 100) //업무량 +
                            {
                                end_flag = 17;
                            }
                            else //업무량 -
                            {
                                end_flag = 16;
                            }
                        }
                        else //직원 -
                        {
                            if (data_arr[2] >= 100) //업무량 +
                            {
                                end_flag = 15;
                            }
                            else //업무량 -
                            {
                                end_flag = 14;
                            }
                        }
                    }
                }
                else // 돈 + 직원 플래그
                {
                    if(data_arr[0] >= 100)
                    {
                        if (data_arr[1] >= 100)
                        {
                            end_flag = 12;
                        }
                        else
                        {
                            end_flag = 10;
                        }
                    }
                    else
                    {
                        if (data_arr[1] >= 100)
                        {
                            end_flag = 8;
                        }
                        else
                        {
                            end_flag = 6;
                        }
                    }
                }
            }
            else if (end_arr[2]) // 돈 + 업무량 플래그
            {
                if(data_arr[0] >= 100)
                {
                    if(data_arr[2] >= 100)
                    {
                        end_flag = 13;
                    }
                    else
                    {
                        end_flag = 11;
                    }
                }
                else
                {
                    if (data_arr[2] >= 100)
                    {
                        end_flag = 9;
                    }
                    else
                    {
                        end_flag = 7;
                    }
                }
            }
            else // only 돈 플래그
            {
                if (data_arr[0] >= 100)
                {
                    end_flag = 3;
                }
                else
                {
                    end_flag = 0;
                }
            }
        }
        else if (end_arr[1]) // 직원 플래그
        {
            if (end_arr[2]) // 업무량 플래그
            {
                if (data_arr[1] >= 100)
                {
                    if (data_arr[2] >= 100)
                    {
                        end_flag = 25;
                    }
                    else
                    {
                        end_flag = 24;
                    }
                }
                else
                {
                    if (data_arr[2] >= 100)
                    {
                        end_flag = 23;
                    }
                    else
                    {
                        end_flag = 22;
                    }
                }
            }
            else
            {
                if (data_arr[1] >= 100)
                {
                    end_flag = 4;
                }
                else
                {
                    end_flag = 1;
                }

            }
        }
        else if(end_arr[2]) // 업무량플래그
        {
            if (data_arr[2] >= 100)
            {
                end_flag = 5;
            }
            else
            {
                end_flag = 2;
            }
        }

        End_reword(end_flag);

        s = end_str[end_flag];

        if (end_arr[3])
        {
            s = "국내 점유율이 모두 찼네요 해피 엔딩이에요\n";
            end_scene = 0;
        }
        End_t.text = "END\n" + s;
        StartCoroutine(Fade_ENDING(end_scene));
        data.ResetData();
        data.SetGamePlay(1);// 새로시작.
    }

    void End_reword(int f)
    {
        Load_end();
        if (end_array[f] == 0)
        {
            data.SetGold(10);
        }
        end_array[f]++;
        string str = "";
        for(int i = 0; i < 26; i++)
        {
            str += end_array[i] + " ";
        }
        data.SetEnd(str);       
    }

	// Use this for initialization
	void Start () {
        Load_img();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
