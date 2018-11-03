using UnityEngine.Audio;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public Sound[] sounds;

    // Use this for initialization
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
