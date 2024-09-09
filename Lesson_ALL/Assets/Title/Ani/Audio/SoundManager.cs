using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


//bgm처럼 하나만 재생하면 되기때문에 싱글톤으로 만듦
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {  get; private set; }

    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        bgm.clip = clip;
        bgm.Play();
    }

    public void StopBGM()
    {
        if (bgm.isPlaying == false)
            return;

        bgm.Stop();
    }

    public void PauseBGM()
    {
        if (bgm.isPlaying == false)
            return;

        bgm.Pause();
    }

    public void SetBGM(float volum, float pitch = 1f)
    {
        bgm.volume = volum;
        bgm.pitch = pitch;
    }

    //이런식으로 하게 되면 사운드가 끊기는 상황이 발생함!!
    //public void PlaySFX(AudioClip clip)
    //{
    //    sfx.clip = clip;
    //    sfx.Play();
    //}

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void SetSFX(float volum, float pitch = 1f)
    {
        sfx.volume = volum;
        sfx.pitch = pitch;
    }

}
