using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundOnClick()
    {
        musicSource.Play();
    }
}
