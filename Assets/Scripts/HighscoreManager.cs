using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    public Text score;
    public Text highScore;
    void Start()
    {
        highScore.text=PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    void Update()
    {
        score.text=PlayerStats.currentScore.ToString();
        if(PlayerStats.currentScore>PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", PlayerStats.currentScore);
            highScore.text=PlayerStats.currentScore.ToString();
        }
    }
}
