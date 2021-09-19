using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreLoader : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    void Start()
    {
        highScoreText.text = "High Score- ";
        highScoreText.text += PlayerPrefs.GetInt("High Score", 0);
    }
    public void SetHighScore(int highScore)
    {
        int currentHighScore = PlayerPrefs.GetInt("High Score", 0);
        if (currentHighScore < highScore){
            PlayerPrefs.SetInt("High Score", highScore);
            highScoreText.text = "High Score- ";
            highScoreText.text += PlayerPrefs.GetInt("High Score");
        }
    }
    public void ResetHighScore(){
        PlayerPrefs.DeleteKey("High Score");
        highScoreText.text = "High Score- 0";
    }
}
