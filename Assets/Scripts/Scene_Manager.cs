using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //--------------------------------Load -------------------------------

    public void loadNewGame()
    {
        SceneManager.LoadScene(3);
    }

    public void loadCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void loadHowTo()
    {
        SceneManager.LoadScene(1);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
