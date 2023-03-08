using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;
    public GameObject player;
    private float distance;
    [SerializeField]
    private float agroRange = 5f;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = player.transform.localPosition.x - transform.position.x;
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y)* Mathf.Rad2Deg;
        if(distance < agroRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            
            animator.Play("Enemy2_run");
            
        }
        else
        {
            
            animator.Play("Enemy2_idle");
        }

        if(movement < -Mathf.Epsilon)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        

        

    }
    
    


}
