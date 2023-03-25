using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tmpScale = sr.transform.localScale;

        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;


        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight * Screen.width/Screen.height;

        tmpScale.y = screenHeight / height;
        tmpScale.x = screenWidth / width;

        transform.localScale = tmpScale;

    }

    
}
