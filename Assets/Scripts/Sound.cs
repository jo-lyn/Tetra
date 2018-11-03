using UnityEngine.Audio;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
	[Range(0.1f, 3f)]
    public float pitch;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
