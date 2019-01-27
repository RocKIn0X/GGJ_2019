using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTriggered : MonoBehaviour
{
    public bool isActivated;
    public float on;
    // Start is called before the first frame update
    void Start()
    {
        on = 0;
        isActivated = false;
    }

    // Update is called once per frame
    /*void Update()
    {
 */
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Dog" )
        {
            on++;
            isActivated = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Dog")
        {
            on--;
            if (on <= 0)
            {
                isActivated = false;
            }
        }
    }
}
