using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private BoxCollider2D leftBorder;
    [SerializeField]
    private BoxCollider2D rightBorder;
    private Vector3 velocity = Vector3.zero;
    private bool playerOutOfBox;

    void Start()
    {
        playerOutOfBox = false;
        minX = transform.position.x;
        minY = transform.position.y;
        maxY = transform.position.y + 3f;
    }

    void FixedUpdate()
    {
        if (playerOutOfBox)
        {
            Vector3 desiredPosition = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), transform.position.y, transform.position.z);
            Vector3 SmoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
            transform.position = SmoothPosition;
        }
    }

    public void SetIsPlayerOutOfBorder(bool b)
    {
        playerOutOfBox = b;
        offset = transform.position - target.position;
    }
}
