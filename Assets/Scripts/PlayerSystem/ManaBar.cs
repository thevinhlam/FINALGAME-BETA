using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    public Player _playerdata;

    public Image _manabar;
    public float _manabarnumber;
    public Slider _manabarslider;
    public GameObject _manabargo;
    // Start is called before the first frame update
    void Start()
    {
        _manabarslider= FindObjectOfType<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _manabar1();
    }

    void _manabar1()
    {
        _manabarnumber = _playerdata._manaMax / 100;
        _manabarslider.value = _manabarnumber;

        if (_manabarslider.value <= 0.06)
        {
            _manabargo.SetActive(false);
        }
        else
        {
            _manabargo.SetActive(true);
        }
    }

}
