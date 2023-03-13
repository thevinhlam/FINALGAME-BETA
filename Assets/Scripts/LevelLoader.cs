using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        LoadScene();
    }

    IEnumerator LoadScene()
    {
        if (Input.GetMouseButtonDown(0)) ;
        {
            //Play animation
            transition.SetTrigger("Start");
            //Wait
            yield return new WaitForSeconds(transitionTime);
        }
    }
}
