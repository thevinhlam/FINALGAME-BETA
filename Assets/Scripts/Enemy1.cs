using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 6f;
    Rigidbody2D myBody;
    
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFacingRight())
        {
            myBody.velocity = new Vector2(speed, 0f);
        }
        else
        {
            myBody.velocity = new Vector2(-speed, 0f);
        }
        
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        transform.localScale = new Vector2(-(transform.localScale.x),transform.localScale.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        transform.localScale = new Vector2(-(transform.localScale.x), transform.localScale.y);

    }



}
