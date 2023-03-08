using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] public float runSpeed = 3f;
    [SerializeField] public float jumpSpeed = 1f;


    Rigidbody2D _myRigidbody;




    public int _obpoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _running();
        _flying();

    }

    void _running()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _myRigidbody.velocity = new Vector2(runSpeed, _myRigidbody.velocity.y);
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _myRigidbody.velocity = new Vector2(-runSpeed, _myRigidbody.velocity.y);
        }

        //else if (Input.GetKey(KeyCode.Space))
        //{
        //    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);
        //}

        else
        {
            _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, _myRigidbody.velocity.y);
        }
    }

    void _flying()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, jumpSpeed);
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Trap")
        {
            Invoke("ResetScene", 1);
        }
    }
}