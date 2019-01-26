using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBorderCamera : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !PlayerController.instance.IsPlayerFaceRight())
        {
            transform.parent.GetComponent<CameraController>().SetIsPlayerOutOfBorder(true);
        }
    }
}
