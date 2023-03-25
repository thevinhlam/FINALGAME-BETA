using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public KeysText _keyText;

    [SerializeField]
    private bool _isTutorail;


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

        if (_keyText._returnKey() == 1 && _isTutorail)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _openDoor();
    }
}
