using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public GameObject bisu,tuto_ui;
    private DataScript data = new DataScript();
    public Text bisu_t;
    public Image img;
    int n;//말 순서
    int m;//그림 순서
    Sprite[] tuto_img = new Sprite[5];

    private string[] dialog = { "안녕하세요\n저는 사장님의 회사 경영을 도와드리는 심비서입니다. " ,
        "업무의 방식에 대해 간단하게 설명해 드릴게요.",
        "왼쪽 칸을 보시면 직원들의 이름과 얼굴이 나옵니다.",
        "그들 각자 원하는 바에 대해 결재 요청을 하죠.",
        "탁자 위를 보시면 직원들이 가져온 결재 서류가 준비되어 있죠.",
        "사장님께서는 그들의 결재 서류를 확인한 후 결재 여부를 선택하시면 됩니다.",
        "결재 내용을 허가하고 싶으신 경우 결재 서류 아래 사인을 하시면 되고",
        "허락하고 싶지 않으시다면 결재서류 윗부분을 들어 직원 얼굴에게 돌려주시면 됩니다.",
        "사장님의 선택에 따라 회사의 자금, 직원들의 애사심, 외부 업무량이 바뀌고",
        "사장님께서는 이 3가지 요소를 잘 조절해서 회사의 시장 점유율을 높히시면 됩니다.",
        "여기까지 간단한 회사 경영 요령입니다.",
        "전화를 통해 저를 호출 하면 다시 한번 설명해 드리겠습니다.",
        "그리고 그밖에 다양한 업무에 도움이 될 수 있으니 자주 찾아주세요!"};
    private string[] bisu_dialog = { "안녕하세요\n저는 사장님의 회사 경영을 도와드리는 심비서입니다. ", "안녕하세요\n픽셀 왕국의 상인 출신 김픽셀이에요.","안녕하세요.\n원하시는 것이 있습니까?","삐릭삐릭\n뚜루루루",};


    private void GetImg()
    {
        for (int i = 0; i < 5; i++)
        {
            string path = "Images/tutorials/tuto" + (i+1);
            tuto_img[i] = Resources.Load(path, typeof(Sprite)) as Sprite;
        }
    }
    public void ShowTutorial() //튜토리얼 보여주기
    {
        GetImg();
        n = 0;
        m = 0;
        bisu.SetActive(true);
        tuto_ui.SetActive(true);
        img.color = new Vector4(1, 1, 1, 0);
        int i = data.GetCurrentBisu();
        bisu_t.text = bisu_dialog[i];
    }

    public void NextTuto() //클릭할 때 마다 넘어감.
    {
        n++;
        if(n == 12)
        {
            img.color = new Vector4(1, 1, 1, 0);
            tuto_ui.SetActive(false);
        }
        if (n == 2 || n == 5 || n==6 || n==7 || n==8) 
        {
            img.color = new Vector4(1, 1, 1, 1);
            img.sprite = tuto_img[m];
            m++;
        }
        bisu_t.text = dialog[n];
    }
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
