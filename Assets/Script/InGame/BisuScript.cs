using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BisuScript : MonoBehaviour {
    private DataScript data = new DataScript();
    public Text bisu_t;

    private string[] bisu_dialog = { "안녕하세요\n저는 사장님의 회사 경영을 도와드리는 심비서입니다. ", "안녕하세요\n픽셀 왕국의 상인 출신 김픽셀이에요.", "안녕하세요.\n원하시는 것이 있습니까?", "삐릭삐릭\n뚜뚜뚜뚜\n뚜루루루..삐삐빅삐빅삐빅", };


    public void SetBisuText()
    {
        int i = data.GetCurrentBisu();
        bisu_t.text = bisu_dialog[i];
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
