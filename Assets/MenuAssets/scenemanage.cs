using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenemanage : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene(3);
    }
    public void howtoplay()
    {
        SceneManager.LoadScene(1);
    }
    public void credit()
    {
        SceneManager.LoadScene(2);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void exit()
    {
        Application.Quit();
    }
}
