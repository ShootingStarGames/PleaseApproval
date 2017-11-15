using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour {

    public Image background;
    public Image logo;

    private IEnumerator fadeOut() {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < 60; i++) {
            logo.color = new Vector4(1, 1, 1, 1-(float)i/40);
            background.color = new Vector4(1, 1, 1, 1 - (float)i / 50);
            yield return new WaitForSeconds(0.02f);
        }
        Screen.SetResolution(1280, 720, true);
        SceneManager.LoadScene("MainMenu");
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(fadeOut());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
