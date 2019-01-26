using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpHole : MonoBehaviour
{
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetDestination ()
    {
        return destination.position;
    }
}
