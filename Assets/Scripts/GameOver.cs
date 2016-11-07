using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public Renderer[] medals;
    public TextMesh finalScoreText;
    public TextMesh bestScoreText;
    public GameObject newObj;

	void Start ()
    {
        newObj.SetActive(false);

	    foreach (Renderer m in medals)
        {
            m.enabled = false;
        }
	}
	void Update ()
    {
	    
	}
    public void FinalScore(int finalScore)
    {
        if (finalScore > PlayerPrefs.GetInt("SCORE"))
        {
            PlayerPrefs.SetInt("SCORE", finalScore);
            newObj.SetActive(true);
        }
        else
        {
            newObj.SetActive(false);
        }

        finalScoreText.text = finalScore.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("SCORE").ToString();

        if (PlayerPrefs.GetInt("SCORE") > 9)
        {
            medals[0].enabled = true;
        }
        else if (PlayerPrefs.GetInt("SCORE") > 19)
        {
            medals[1].enabled = true;
        }
        else if (PlayerPrefs.GetInt("SCORE") > 29)
        {
            medals[2].enabled = true;
        }
        else if (PlayerPrefs.GetInt("SCORE") > 39)
        {
            medals[3].enabled = true;
        }
    }
}