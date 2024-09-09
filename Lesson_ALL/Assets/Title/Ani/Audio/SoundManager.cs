using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


//bgmó�� �ϳ��� ����ϸ� �Ǳ⶧���� �̱������� ����
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

    //�̷������� �ϰ� �Ǹ� ���尡 ����� ��Ȳ�� �߻���!!
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
