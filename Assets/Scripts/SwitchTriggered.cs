using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTriggered : MonoBehaviour
{
    public bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
 
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isActivated = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isActivated = false;
        }
    }
}
