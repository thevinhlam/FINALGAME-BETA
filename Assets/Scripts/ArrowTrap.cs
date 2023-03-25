using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField]
    Transform destination1;
    [SerializeField]
    Transform destination2;
    [SerializeField]
    float moveSpeed = 4f;
    [SerializeField] float attackCoolDown;
    [SerializeField] Transform arrowPoint;
    [SerializeField] GameObject[] arrows;
    float coolDownTimer;
    Transform nextPos;
    
    void Start()
    {
        nextPos = destination1;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        coolDownTimer += Time.deltaTime;
        if(coolDownTimer >= attackCoolDown)
        Attack();
    }
    void Attack()
    {
        coolDownTimer = 0;
        arrows[FindArrow()].transform.position = arrowPoint.position;
        arrows[FindArrow()].GetComponent<Arrow>().ActivateProjectile();
    }
    int FindArrow()
    {
        for(int i = 0; i< arrows.Length;i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;

        }
        return 0;
    }
    void Moving()
    {
        if(transform.position.x == destination1.position.x)
        {
            nextPos = destination2;
        }
        else if(transform.position.x == destination2.position.x)
        {
            nextPos = destination1;
        }
        
            transform.position = Vector2.MoveTowards(transform.position, nextPos.transform.position, moveSpeed * Time.deltaTime);        
    }
    
    

    
}
