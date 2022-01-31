using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;


    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool playOnAwake;
    public bool loop;

    public float spacialBlend;

    [HideInInspector]
    public AudioSource source;
    
    public void SetSpatial(float spacialBlend)
    {
        source.spatialBlend = spacialBlend;
    }


}