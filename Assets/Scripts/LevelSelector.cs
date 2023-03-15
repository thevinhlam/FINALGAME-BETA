using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
public class LevelSelector : MonoBehaviour
{
    public int level;
    public Text levelText;

    public int lastlevel;
    // Start is called before the first frame update
    void Start()
    {
       levelText.text = level.ToString();
    }

    public void OpenScene() 
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }

    public void _LoadCurrentScene()
    {
        string json = File.ReadAllText(Application.dataPath + "/SaveLastScene.json");
        SaveXLoadDDD data = JsonUtility.FromJson<SaveXLoadDDD>(json);

        lastlevel = data._scenenumber;
        SceneManager.LoadScene("Level " + lastlevel.ToString());
    }


}
