using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float resetTime;
    float lifeTime;
    public void ActivateProjectile()
    {
        lifeTime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementspeed = speed * Time.deltaTime;
        transform.Translate(0, movementspeed, 0);
        lifeTime += Time.deltaTime;
        if(lifeTime > resetTime)
            gameObject.SetActive(false);
    }
}
