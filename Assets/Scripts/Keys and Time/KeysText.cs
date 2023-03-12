using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeysText : MonoBehaviour
{

    [SerializeField]
    public int _totalKeys;
    
    public TextMeshProUGUI _numKeys;

    public Keys _getKey;
    public int _Keyplus = 0;
    private void Start()
    {
        _numKeys.text = "0/" + _totalKeys;
    }
    public void _AddPoint(int point)
    {
        if (point < _totalKeys)
        {
            _numKeys.text = "" + point + "/" +_totalKeys;
        }
        else
        {
            _numKeys.text = _totalKeys + "/" + _totalKeys;
        }
    }

    public void _GetKeynum()
    {
        _Keyplus++;

            _numKeys.text = "" + _Keyplus + "/" + _totalKeys;

    }

    public int _returnKey()
    {
        return _Keyplus;
    }
}
