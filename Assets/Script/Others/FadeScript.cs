using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {
    public bool text;
    public bool loop;
    public int speed = 4;

    IEnumerator LoopFade() {    //페이드인아웃 반복
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 1; i <= speed; i++)
            {
                if (text)   //텍스트!
                    this.GetComponent<Text>().color = new Vector4(1, 1, 1, 1 - (float)i / speed);
                else        //이미지!
                    this.GetComponent<Image>().color = new Vector4(1, 1, 1, 1 - (float)i / speed);

                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitForSeconds(0.5f);
            for (int i = 1; i <= speed; i++)
            {
                if (text)   //텍스트!
                    this.GetComponent<Text>().color = new Vector4(1, 1, 1, (float)i / speed);
                else        //이미지!
                    this.GetComponent<Image>().color = new Vector4(1, 1, 1, (float)i / speed);

                yield return new WaitForSeconds(0.02f);
            }
        }
    }
    IEnumerator FadeIn() {
        yield return null;
    }
    IEnumerator FadeOut() {
        yield return null;
    }
	// Use this for initialization
	void Start () {
        if (loop)
            StartCoroutine(LoopFade());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
