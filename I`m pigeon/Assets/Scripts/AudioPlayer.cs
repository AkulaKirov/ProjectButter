using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(menuName ="Audio Events/Simple")]
public class AudioPlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;
    [MinMax(0, 1)] public Vector2 volume;
    [MinMax(-3, 3)] public Vector2 pitch;


    private void Start()
    {


    }

    public void Play(int status)
    {
        
        if (clips.Length == 0) return;
        source.volume = Random.Range(volume.x, volume.y);
        source.pitch = Random.Range(pitch.x, pitch.y);

        switch (status)
        {
            case 0: break;
            case 1: 
                Fire();
                break;
            case 2:
                Reload();
                break;
            case 3:
                Reload2();
                break;
        }
    }

    void Fire()
    {
        source.clip = clips[0];
        source.Play();
    }

    void Reload()
    {
        source.clip = clips[1];
        source.Play();
    }

    void Reload2()
    {
        source.clip = clips[2];
        source.Play();
    }
}
