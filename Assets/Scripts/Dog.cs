using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dog : MonoBehaviour
{
    [System.Serializable]
    public enum DogState
    {
        STAND,
        FOLLOW,
        SIT
    }

    private Animator anim;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float distanceToPlayer = 1f;
    private float direction;
    private bool faceRight;
    private bool isSit;
    private Rigidbody2D rb;
    private Transform target;
    private bool isFollow;

    public LayerMask whatIsPlayer;
    public DogState state;

    #region Singleton Object
    public static Dog instance = null;

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
        isFollow = true;
        isSit = false;
        state = DogState.FOLLOW;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position.x - transform.position.x) > 0f ? 1 : -1;

        switch (state)
        {
            case DogState.STAND:
                break;
            case DogState.FOLLOW:
                MoveToTarget();
                Flip(direction);
                break;
            case DogState.SIT:
                break;
        }
    }

    private void FixedUpdate()
    {
        
    }

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        //Debug.Log(Vector2.Distance(transform.position, new Vector2(target.position.x, transform.position.y)));
        if (Vector2.Distance(transform.position, new Vector2(target.position.x, transform.position.y)) < 0.05f)
        {
            Debug.Log(state);
            isFollow = false;
            anim.SetBool("Follow", false);
            state = DogState.STAND;
        }
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

    void CheckPlayerFromRay()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, new Vector2(direction, 0), distanceToPlayer, whatIsPlayer);
        if (hitInfo.collider != null)
        {
            isFollow = false;
            state = DogState.STAND;
            anim.SetBool("Follow", isFollow);
        }
        else
        {
            isFollow = true;
            state = DogState.FOLLOW;
            anim.SetBool("Follow", isFollow);
        }
    }

    public void Command (Transform _target)
    {
        if (isFollow)
        {
            Debug.Log("Stop Follow");
            state = DogState.SIT;
            isFollow = false;
            anim.SetBool("Follow", isFollow);
            rb.velocity = Vector2.zero;
            anim.SetTrigger("SitCommand");
        }
        else
        {
            Debug.Log("Continue Follow");
            target = _target;
            state = DogState.FOLLOW;
            isFollow = true;
            anim.SetBool("Follow", isFollow);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.collider, true);
        }
    }
}
