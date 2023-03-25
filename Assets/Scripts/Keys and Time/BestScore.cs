using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _BestScoreText;

    public SaveXLoad _load;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _BestScoreText.text = "BestScore: " + _load._BestScoretextload;
    }
}
