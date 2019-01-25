using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField]
    private float climbSpeed;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float dirClimb = Input.GetAxis("Vertical");

            Debug.Log(dirClimb);

            if (dirClimb > 0.1f)
            {
                PlayerController.instance.IsOnLadder = true;
                other.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

            if (PlayerController.instance.IsOnLadder)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, dirClimb * climbSpeed);
            } 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController.instance.IsOnLadder = false;
        Debug.Log(PlayerController.instance.IsOnLadder);
        other.GetComponent<Rigidbody2D>().gravityScale = 3;
    }
}
