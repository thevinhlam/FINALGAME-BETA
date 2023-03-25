using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]

public class SaveXLoad : MonoBehaviour
{
    //public InputField _IDwords;

    public float _dataload;

    public string _BestScoretextload;

    public string _gettime;

    public Timer _gettimuu;

    public KeysText _keyTextx;

    public BoxCollider2D _SaveBoxCollider;

    public int _currentScenenum;

    [SerializeField] private bool _Level1;
    [SerializeField] private bool _Level2;
    [SerializeField] private bool _Level3;

    [SerializeField] 
    private bool _isTutorial;

    public Player _playerisgod;

    public GameObject GodMenu;
    public GameObject ResetMenu;

    private bool _4debugmenu = true;

    [SerializeField] public TextMeshProUGUI _Goooodd;

    void Start()
    {
        _SaveBoxCollider = gameObject.GetComponent<BoxCollider2D>();
        _BestScoretextload = "None";
        Load();
    }
    private void Update()
    {
        _bbb();
        SaveDone();
        ActivateDebug();
    }
    public void Save()
    {
        SaveXLoadDDD data = new SaveXLoadDDD();
        data._dgettime = _gettime;

        string json = JsonUtility.ToJson(data, true);
        if (_Level1 && !_Level2 && !_Level3)
        {
            File.WriteAllText(Application.dataPath + "/SaveLevel1.json", json);
        }
        if (_Level2 && !_Level1 && !_Level3)
        {
            File.WriteAllText(Application.dataPath + "/SaveLevel2.json", json);
        }
        if (_Level3 && !_Level2 && !_Level1)
        {
            File.WriteAllText(Application.dataPath + "/SaveLevel3.json", json);
        }
        if (!_Level3 && !_Level2 && !_Level1 && _isTutorial)
        {
            File.WriteAllText(Application.dataPath + "/SaveLevelTT.json", json);
        }

    }

    public void Load()
    {
        if(_Level1 && !_Level2 && !_Level3)
        {
            string json = File.ReadAllText(Application.dataPath + "/SaveLevel1.json");
            SaveXLoadDDD data = JsonUtility.FromJson<SaveXLoadDDD>(json);

            //_IDwords.text = data._dgettime;
            _BestScoretextload = data._dgettime;
            _dataload = (float)Convert.ToDouble(data._dgettime);
        }
        if (_Level2 && !_Level1 && !_Level3)
        {
            string json = File.ReadAllText(Application.dataPath + "/SaveLevel2.json");
            SaveXLoadDDD data = JsonUtility.FromJson<SaveXLoadDDD>(json);

            //_IDwords.text = data._dgettime;
            _BestScoretextload = data._dgettime;
            _dataload = (float)Convert.ToDouble(data._dgettime);
        }
        if (_Level3 && !_Level2 && !_Level1)
        {
            string json = File.ReadAllText(Application.dataPath + "/SaveLevel3.json");
            SaveXLoadDDD data = JsonUtility.FromJson<SaveXLoadDDD>(json);

            //_IDwords.text = data._dgettime;
            _BestScoretextload = data._dgettime;
            _dataload = (float)Convert.ToDouble(data._dgettime);
        }
        if (!_Level3 && !_Level2 && !_Level1 && _isTutorial)
        {
            string json = File.ReadAllText(Application.dataPath + "/SaveLevelTT.json");
            SaveXLoadDDD data = JsonUtility.FromJson<SaveXLoadDDD>(json);

            //_IDwords.text = data._dgettime;
            _BestScoretextload = data._dgettime;
            _dataload = (float)Convert.ToDouble(data._dgettime);
        }
    }

    public void ResetScore()
    {
        SaveXLoadDDD data = new SaveXLoadDDD();
        data._dgettime = "None";

        string json = JsonUtility.ToJson(data, true);
        if (_Level1 && !_Level2 && !_Level3)
        {
            File.WriteAllText(Application.dataPath + "/SaveLevel1.json", json);
        }
        if (_Level2 && !_Level1 && !_Level3)
        {
            File.WriteAllText(Application.dataPath + "/SaveLevel2.json", json);
        }
        if (_Level3 && !_Level2 && !_Level1)
        {
            File.WriteAllText(Application.dataPath + "/SaveLevel3.json", json);
        }
        if (!_Level3 && !_Level2 && !_Level1 && _isTutorial)
        {
            File.WriteAllText(Application.dataPath + "/SaveLevelTT.json", json);
        }
    }

    public void DebugGod()
    {
        if(_playerisgod._godmode == true)
        {
            _playerisgod._godmode = false;
            _Goooodd.text = "GOD MODE OFF";
        }
        else if(_playerisgod._godmode == false)
        {
            _playerisgod._godmode = true;
            _Goooodd.text = "GOD MODE ON";
        }
    }

    public void ActivateDebug()
    {
        if(Input.GetKeyDown(KeyCode.K) && _4debugmenu)
        {
            GodMenu.SetActive(true);
            ResetMenu.SetActive(true);
            _4debugmenu = false;
        }
        else if (Input.GetKeyDown(KeyCode.K) && !_4debugmenu)
        {
            GodMenu.SetActive(false);
            ResetMenu.SetActive(false);
            _4debugmenu = true;
        }
    }

    public void _bbb()
    {
        _gettime = _gettimuu._aaa();
    }

    public int _getScenenum()
    {
        if (_isTutorial)
        {
            _currentScenenum = 1;
        }
        else if (_Level1)
        {
            _currentScenenum = 1;
        }
        else if (_Level2)
        {
            _currentScenenum = 2;
        }
        else if (_Level3)
        {
            _currentScenenum = 3;
        }
        return _currentScenenum;
    }

    public void SaveDone()
    {
        if (_dataload > _gettimuu._aaaFloat())
        {
            if (_keyTextx._returnKey() == 5)
            {
                _SaveBoxCollider.enabled = true;
            }
            if (_keyTextx._returnKey() == 1 && _isTutorial)
            {
                _SaveBoxCollider.enabled = true;
            }
        }
        else
        {
            _SaveBoxCollider.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Save();
    }

}
