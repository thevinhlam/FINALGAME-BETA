using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public KeysText _KeyTexts;
    [SerializeField]
    private AudioSource _keySound;


    private void Start()
    {
        _keySound = FindObjectOfType<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(gameObject);

        if (collision.tag == "Player")
        {
            _keySound.Play();
            _KeyTexts._GetKeynum();
            gameObject.SetActive(false);
        }
    }

}
