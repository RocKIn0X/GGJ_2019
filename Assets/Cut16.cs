using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cut16 : MonoBehaviour
{
    public void Start()
    {
        //animateSprite1 = scene1.GetComponent<AnimateSprite>();
        StartCoroutine(switchImage());
    }

    public IEnumerator switchImage()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

}