using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    GameObject player;

    Animator animator;
    [SerializeField]
    float speed = 4f;
    [SerializeField]
    float agroRange = 5f;
    [SerializeField]
    Transform castPoint;

    bool isChasing = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Searching(rb));

    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer())
        {
            ChasePlayer();
            
        }
        else
        {
            StopChase();
            
        }
    }
    void ChasePlayer()
    {
        if(IsFacingRight())
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        isChasing = true;
    }
    void StopChase()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        isChasing = false;
    }
    void Turning()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); 
    }
    IEnumerator Searching(Rigidbody2D rb)
    {
        if(isChasing == true)
        {
            yield return null;
        }
        else
        {
            Turning();
            yield return new WaitForSeconds(2f);
        }

        
        StartCoroutine(Searching(rb));
        
    }
    bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    bool CanSeePlayer()
    {
        bool val = false;
        
        RaycastHit2D hit = Physics2D.Linecast(transform.position,castPoint.position,1 <<LayerMask.NameToLayer("Action"));
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }

            //Debug.DrawLine(transform.position, castPoint.position, Color.blue);
            

        }
        else
        {
            //Debug.DrawLine(transform.position, castPoint.position, Color.red);
        }
        return val;
    }
    
    
}
