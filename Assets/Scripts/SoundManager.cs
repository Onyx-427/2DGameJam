using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource[] changeSources;
    [SerializeField] private AudioSource[] BackgroundMusic;
    void Update()
    {
        instance = this;
    }

    public void PickRandomAudio()
    {
        int num = Random.Range(0, changeSources.Length);
        changeSources[num].Play();
    }

    public void PlayBGMusic(int num)
    {
        BackgroundMusic[0].Stop();
        BackgroundMusic[1].Stop();
        BackgroundMusic[2].Stop();
        BackgroundMusic[num].Play();
    }
}
