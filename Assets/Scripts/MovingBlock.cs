using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingBlock : MonoBehaviour
{
    private float traveled;
    private bool isTriggered;
    public float isVertical;
    public float isHoriontal;
    public float isPlus;
    public float distance;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        traveled = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
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
                traveled += 1;
                rb.velocity = new Vector2(isPlus * 1 * isHoriontal, isPlus * 1 * isVertical);
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
                traveled -= 1;
                rb.velocity = new Vector2(isPlus * -1 * isHoriontal, isPlus * -1 * isVertical);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);

            }
        }
    }
}
