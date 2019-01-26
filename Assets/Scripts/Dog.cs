using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dog : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private float speed;
    private bool faceRight;
    private Rigidbody2D rb;
    private Transform target;
    private bool isFollow;

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

        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = target.position.x - transform.position.x;

        if (isFollow)
        {
            MoveToTarget();
            Flip(direction);
        } 
    }

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
    }

    void StopMove ()
    {
        target.position = transform.position;
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

    public void Command ()
    {
        if (isFollow)
        {
            anim.SetTrigger("SitCommand");
            Debug.Log("Stop Follow");
        }
        else
        {
            anim.SetTrigger("Follow");
            Debug.Log("Continue Follow");
        }
        isFollow = !isFollow;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.collider, true);
        }
    }
}
