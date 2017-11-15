using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PaperUpActionScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public GameObject PaperObj;
	public ViewPaperScript ViewPaperSrc;
    public GameObject Box_obj;
	private Vector3 MousePaperPos;	// 마우스로 클릭한 Paper Pos
	private bool isDrag = false;

	public void OnPointerDown(PointerEventData eventData) {
        AudioScript.Instance().playDrag();
        if (ViewPaperSrc.GetMove())
            return;
		isDrag = true;
        MousePaperPos = Input.mousePosition - PaperObj.transform.position;
        Box_obj.transform.position = new Vector3(Box_obj.transform.position.x, Box_obj.transform.position.y, 20); // 거절 확인용
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (ViewPaperSrc.GetMove())
            return;
        AudioScript.Instance().playDrag();
		isDrag = false;
        Box_obj.transform.position = new Vector3(Box_obj.transform.position.x, Box_obj.transform.position.y, 0); // 거절 확인용
        // Pass Approval
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Input.mousePosition;
		if (isDrag) {
			PaperObj.transform.position = pos-MousePaperPos;
		}
	}
}
