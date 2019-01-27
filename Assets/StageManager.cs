using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    private void Awake()
    {
        //Singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this; //In this case, it runs when you play game first time only.
        }
    }

    [SerializeField]
    private GameObject coverPanel;
    private Animator coverPanelAnim;
    public bool PlayerFinish { get; set; }
    public bool DogFinish { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerFinish = false;
        DogFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerFinish && DogFinish)
        {
            PlayerFinish = false;
            DogFinish = false;
            StartCoroutine(WinCoroutine());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator LoseCoroutine()
    {
        coverPanelAnim = coverPanel.GetComponent<Animator>();
        coverPanelAnim.SetTrigger("Lose");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator WinCoroutine()
    {
        coverPanelAnim = coverPanel.GetComponent<Animator>();
        coverPanelAnim.SetTrigger("Win");
        yield return new WaitForSeconds(2.0f);
        // Load next scene
        Debug.Log("Load Next Scene");
    }

    public void WinningGame()
    {
        StartCoroutine(WinCoroutine());
    }

    public void LosingGame()
    {
        StartCoroutine(LoseCoroutine());
    }
}
