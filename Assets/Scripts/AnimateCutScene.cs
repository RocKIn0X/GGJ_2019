using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimateCutScene : MonoBehaviour
{
    public string page;
    //private AnimateSprite animateSprite1;
    public void Start()
    {
        //animateSprite1 = scene1.GetComponent<AnimateSprite>();
        StartCoroutine(playAnimation());
    }

    public IEnumerator playAnimation()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(page);
    }
    
}