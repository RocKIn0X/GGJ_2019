using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private bool faceRight;
    [SerializeField]
    private bool isOnGround;
    [SerializeField]
    private bool jumpRequest;
    private float xScreenMin;
    private float xScreenMax;

    private Rigidbody2D rb;
    private BoxCollider2D playerBox;
    private Vector2 playerSize;
    private Vector2 boxSize;
    private Vector2 playerBoxOffset;
    [SerializeField]
    private float groundedSkin = 0.05f;

    public bool IsOnLadder { get; set; }
    public float screenPadding;
    public float speedX;
    public float jumpForce;
    public LayerMask groundLayer;

    #region Singleton Object
    public static PlayerController instance = null;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        isOnGround = false;
        IsOnLadder = false;
        jumpRequest = false;

        rb = GetComponent<Rigidbody2D>();
        playerBox = GetComponent<BoxCollider2D>();
        playerSize = playerBox.size;
        playerBoxOffset = playerBox.offset;
        boxSize = new Vector2(playerSize.x, groundedSkin);
        SetPositionNotOverViewPort();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        float dirHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirHorizontal * speedX, rb.velocity.y);
        Flip(dirHorizontal);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xScreenMin, xScreenMax), transform.position.y, transform.position.z);
        
        if (jumpRequest)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isOnGround = false;
            jumpRequest = false;
        }
        else
        {
            Vector2 boxCenter = ((Vector2)transform.position + playerBoxOffset) + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
            isOnGround = (Physics2D.OverlapBox(boxCenter, boxSize, 0f, groundLayer) != null);
        }
    }

    void SetPositionNotOverViewPort()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xScreenMin = leftmost.x + screenPadding;
        xScreenMax = rightmost.x - screenPadding;
        Debug.Log("x min: " + xScreenMin + "x max: " + xScreenMax);
    }

    void Flip(float dirHorizontal)
    {
        if ((dirHorizontal > 0 && !faceRight) || (dirHorizontal < 0 && faceRight))
        {
            faceRight = !faceRight;

            Vector2 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}
