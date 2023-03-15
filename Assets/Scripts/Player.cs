using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] public float runSpeed = 3f;
    [SerializeField] public float jumpSpeed = 1f;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform wallCheck;

    public Animator _Animation;

    public KeysText _getKeys;


    Rigidbody2D _myRigidbody;
    public CapsuleCollider2D _myCapCollider;

    public bool _isflying;
    public bool _canJump;
    [SerializeField]
    public bool _isGround;

    public bool _jumpLock = false;

    public float _manaMax = 100;
    public float _manaAmount = 100;
    public float _manaRegen = 1f;

    [SerializeField]
    public bool _godmode;


    public int _obpoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _myCapCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _wallCheck();
        _groundCheck();
        _running();
        _flying();
        _FlipSprite();
        _jumpLockk();
        _AnimationPlayer();
    }

    void _AnimationPlayer()
    {
        _Animation.SetFloat("Speed", Mathf.Abs(_myRigidbody.velocity.x));
        if(_isflying)
        {
            _Animation.SetBool("Jumping", true);
        }
        if(!_isflying)
        {
            _Animation.SetBool("Jumping", false);
        }
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
            if (_isGround)
                _myRigidbody.velocity = new Vector2(0, _myRigidbody.velocity.y);
            else
                _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, _myRigidbody.velocity.y);
        }
    }

    void _flying()
    {


        if (_isGround)
        {
            _manaSysP();
            if (Input.GetKeyDown(KeyCode.Space) && _canJump == true)
            {
                _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, jumpSpeed);
                _canJump = false;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                _canJump = true;
            }
            //_canJump = true;
            _isflying = false;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _canJump = true;
            }

            if (Input.GetKey(KeyCode.Space) && _canJump == true)
            {
                _flying2();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _manaAmount = _manaAmount - 5;
            }
            else
            {
                _manaSysP();
            }
            _isflying = true;
            return;
        }

    }

    void _flying2()
    {
        if (_isflying == true && !_jumpLock)
        {
            if (_manaAmount > 5)
            {
                _myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x, 0.5f * jumpSpeed);
                _manaSys();
            }
        }
    }

    void _manaSys()
    {
        if (_manaAmount >= 5)
        {
            _manaAmount -= _manaRegen * 60 * Time.deltaTime;
            _manaMax = Convert.ToInt32(_manaAmount);
        }
        else
        {
            _manaAmount = 0;
        }
    }

    void _manaSysP()
    {
        if (_manaAmount <= 100)
        {
            _manaAmount += _manaRegen * 20 * Time.deltaTime;
            _manaMax = Convert.ToInt32(_manaAmount);
        }
        else
        {
            _manaAmount = 100;
        }
    }

    void _groundCheck()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            Debug.DrawLine(transform.position, groundCheck.position, Color.red);
            _isGround = true;
        }
        else
        {
            Debug.DrawLine(transform.position, groundCheck.position, Color.blue);
            _isGround = false;
        }
    }

    void _wallCheck()
    {
        if (Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            Debug.DrawLine(transform.position, wallCheck.position, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, wallCheck.position, Color.blue);
        }

    }


    void _FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_myRigidbody.velocity.x) * Math.Abs(_myRigidbody.transform.localScale.x), _myRigidbody.transform.localScale.y);
        }
    }

    void _jumpLockk()
    {
        if (!_isGround && _manaMax == 5)
        {
            _jumpLock = true;
        }
        else if (_isGround)
        {
            _jumpLock = false;
        }
    }


    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy" || collision.tag == "Trap") && !_godmode)
        {
            Invoke("ResetScene", 1);
            _Animation.SetTrigger("Deadd");
            runSpeed = 0;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Trap") && !_godmode)
        {
            Invoke("ResetScene", 1);
            _Animation.SetTrigger("Deadd");
            runSpeed = 0;
        }
    }
}