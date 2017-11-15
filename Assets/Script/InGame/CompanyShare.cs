using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CompanyShare : MonoBehaviour {
    public Image domestic_circle, overseas_circle;
    DataScript data = new DataScript();

    IEnumerator FillDomesticShare(int amount)
    {
        SetDomestic(amount);
        float domestic_amount = (float)data.GetDomestic() * 0.01f;

        for (float i= domestic_circle.fillAmount; i <= domestic_amount; i+=0.01f)
        {
            domestic_circle.fillAmount = i;
            yield return new WaitForSeconds(0.01f);
        }
        for (float i = domestic_circle.fillAmount; i >= domestic_amount; i -= 0.01f)
        {
            domestic_circle.fillAmount = i;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator FillOverseasShare(int amount)
    {
        SetOverseas(amount);
        float overseas_amount = (float)data.GetOverseas() * 0.01f;
        for (float i = overseas_circle.fillAmount; i <= overseas_amount; i += 0.01f)
        {
            overseas_circle.fillAmount = i;
            yield return new WaitForSeconds(0.01f);
        }
        for (float i = overseas_circle.fillAmount; i >= overseas_amount; i -= 0.01f)
        {
            overseas_circle.fillAmount = i;
            yield return new WaitForSeconds(0.01f);
        }
    }


    public int GetDomestic(){
		return PlayerPrefs.GetInt("Domestic");
	}
	public void SetDomestic(int domestic){
        data.SetDomestic(domestic);
	}
	public int GetOverseas(){
		return PlayerPrefs.GetInt("Overseas"); 
	}
	public void SetOverseas(int overseas){
        data.SetOverseas(overseas);
    }
    public void SetShare(int i,int j)
    {
        StartCoroutine(FillDomesticShare(i));
        StartCoroutine(FillOverseasShare(j));
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
