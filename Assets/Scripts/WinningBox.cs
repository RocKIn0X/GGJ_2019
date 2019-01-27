using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player inside");
            StageManager.Instance.PlayerFinish = true;
        }

        if (collision.CompareTag("Dog"))
        {
            Debug.Log("Player inside");
            StageManager.Instance.DogFinish = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StageManager.Instance.PlayerFinish = false;
        }

        if (collision.CompareTag("Dog"))
        {
            StageManager.Instance.DogFinish = false;
        }
    }
}
