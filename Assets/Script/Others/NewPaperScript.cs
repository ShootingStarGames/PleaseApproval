using UnityEngine;
using System.Collections;

public class NewPaperScript : MonoBehaviour {
    public GameObject alertUpDrag;  // 위에 있을 때 나오는 텍스트
    public GameObject alertDownDrag; // 아래에 있을 때 나오는 텍스트

    // Use this for initialization
    void Start () {
        this.transform.localPosition = new Vector2(482, -720);
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localPosition.y < -720)
        {
            this.transform.localPosition = new Vector2(482, -720);
        }
        else if (this.transform.localPosition.y > -0.6f)
        {
            this.transform.localPosition = new Vector2(482, -0.6f);
        }

        // 위에 있을 때 나오는 텍스트 언제 나오는지
        if (this.transform.localPosition.y > -680)
        {
            alertUpDrag.SetActive(false);
        }
        else {
            alertUpDrag.SetActive(true);
        }

        // 아래에 있을 때 나오는 텍스트가 언제 나오는지
        if (this.transform.localPosition.y < -280  ||
            this.transform.localPosition.y > -134)
        {
            alertDownDrag.SetActive(false);
        }
        else
        {
            alertDownDrag.SetActive(true);
        }


 //       Debug.Log(this.transform.localPosition);
    }
}
