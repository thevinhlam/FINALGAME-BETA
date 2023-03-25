using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] float resetTime;
    float lifeTime;
    [SerializeField]
    GameObject player;
    Rigidbody2D rb;
    Vector3 direction;
    float rot;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();        

    }
    public void ActivateProjectile()
    {
        lifeTime = 0;
        
        direction = player.transform.position - transform.position;
        rot = Mathf.Atan2(-direction.x,direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward*(rot+90));
        gameObject.SetActive(true);
    }
    private void Update()
    {   
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        
        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
            gameObject.SetActive(false);
    }
}
