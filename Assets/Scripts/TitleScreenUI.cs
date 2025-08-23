using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreenUI : MonoBehaviour
{
    public void ClickPlay()
    {
        Debug.Log("Play");
        SceneManager.LoadScene("Asteroids");
    }

    public void ClickQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ClickPVP()
    {
        SceneManager.LoadScene("PVP");
    }

    public void ClickRace()
    {
        SceneManager.LoadScene("RaceGame");
    }


}


