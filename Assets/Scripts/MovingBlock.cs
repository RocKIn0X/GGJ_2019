using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingBlock : MonoBehaviour
{
    public GameObject switches;
    private SwitchTriggered switchTriggered;

    private float traveled;
    private bool isTriggered;
    public float isVertical;
    public float isHoriontal;
    public float isPlus;
    public float velo;
    public float distance;
    private Rigidbody2D rb;

    // Start is called before the first frame update

    void Start()
    {
        traveled = 0;
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 8);

    }

    // Update is called once per frame
    void Update()
    {
        switchTriggered = switches.GetComponent<SwitchTriggered>();
        if (switchTriggered.isActivated)
        {
            isTriggered = true;
        }
        else
        {
            isTriggered = false;
        }
    }
    void FixedUpdate()
    {
        if (isTriggered)
        {
            if (traveled <= distance)
            {
                traveled += velo;
                rb.velocity = new Vector2(isPlus * velo * isHoriontal, isPlus * velo * isVertical);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);

            }
        }
        else
        {
            if (traveled >= 0)
            {
                traveled -= velo;
                rb.velocity = new Vector2(isPlus * -velo * isHoriontal, isPlus * -velo * isVertical);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);

            }
        }
    }
}
