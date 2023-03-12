using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public KeysText _keyText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void _openDoor()
    {
        if (_keyText._returnKey() == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _openDoor();
    }
}
