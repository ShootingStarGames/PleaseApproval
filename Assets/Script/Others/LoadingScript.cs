using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScript : MonoBehaviour {
    public Text loadingText;
    private string nextScene;
	public Text tip;

    private IEnumerator loadAsync()
    {
        yield return new WaitForSeconds(1.0f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        while (!operation.isDone)
        {
            yield return operation.isDone;
			loadingText.text = "Loading";// + (int)operation.progress + "%";
        }
    }

	// set tip string
	public void SetTip(string s){
		tip.text = s;
	}
	// set nextScene string
	public void SetNextScene(string s){
		nextScene = s;
	}

    // Use this for initialization
    void Start () {
        StartCoroutine(loadAsync());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
