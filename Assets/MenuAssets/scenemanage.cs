using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenemanage : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene("cut1");
    }
    public void howtoplay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void credit()
    {
        SceneManager.LoadScene("Credit");
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
