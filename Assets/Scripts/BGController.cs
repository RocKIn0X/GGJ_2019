using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public GameObject followCamera;
    public float slow;
    private Vector3 offset;
    private Vector3 oldPosition;

    private float multiplier;
    //private Vector3 right;
    //private Vector3 left;
    // Start is called before the first frame update
    void Start()
    {
        multiplier = 1;
        offset = transform.position - followCamera.transform.position;
        oldPosition = followCamera.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (followCamera.transform.position.x - oldPosition.x > 0.01)
        {
            transform.position = followCamera.transform.position + offset + new Vector3(-1*(multiplier/slow), 0, 0);
            multiplier += 1;
            oldPosition = followCamera.transform.position;
        }
        if (followCamera.transform.position.x - oldPosition.x < -0.01)
        {
            transform.position = followCamera.transform.position + offset + new Vector3(-1 * (multiplier / slow), 0, 0);
            multiplier -= 1;
            oldPosition = followCamera.transform.position;

        }

        // Debug.Log("followX " + followCamera.transform.position.x + " old x " + oldPosition.x + " multi " + multiplier);
    }
}
