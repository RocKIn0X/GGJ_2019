using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBoxStageOne : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player inside");
            StageManager.Instance.WinningGame();
        }
    }
}
