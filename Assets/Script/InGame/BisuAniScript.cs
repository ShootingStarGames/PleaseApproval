using UnityEngine;
using System.Collections;

public class BisuAniScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (BisuAnimation());
	}

	IEnumerator BisuAnimation(){
		int x = 1000;
		int y = 1000;
		bool flag = true;
		while (true) {
			if (flag) {
				x++;
				y--;
			} else {
				x--;
				y++;
			}

			this.transform.localScale = new Vector3 ((float)x/1000, (float)y/1000, 1);

			if (995 > y || y > 1005)
				flag = !flag;
			
			yield return new WaitForSeconds (0.08f);
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
