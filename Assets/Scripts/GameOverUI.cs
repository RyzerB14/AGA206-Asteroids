using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{
    public bool Asteroids;
    public bool PVP;
    public bool Race;
    public TMP_Text ScoreTextBox, HighScoreTextBox;
    public GameObject GameOverPanel;
    public GameObject Celebrate;
    public GameObject Winner;
    void Start()
    {
        Hide();

    }

    public void Hide()
    {
        GameOverPanel.SetActive(false);

    }
    public void Show(bool celebrateHighScore, int score, int highScore)
    {
        ScoreTextBox.text = "Score: " + score.ToString();
        HighScoreTextBox.text = "High Score: " + highScore.ToString();
        GameOverPanel.SetActive(true);
        Celebrate.SetActive(celebrateHighScore);
    }

    public void ClickPlayAgain()
    {if(Asteroids == true)
        { 
         SceneManager.LoadScene("Asteroids"); 
        }
     if(PVP == true)
        {
         SceneManager.LoadScene("PVP");
        }   
     if(Race == true)
        {
         SceneManager.LoadScene("RaceGame");
        }
    }
    public void ClickMainMenu()
    {
        SceneManager.LoadScene("Title");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
