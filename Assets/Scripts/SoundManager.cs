using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;
    [SerializeField] AudioClip wallHit;
    [SerializeField] AudioClip wallBreak;
    [SerializeField] AudioClip hitMiss;
    [SerializeField] AudioClip hitBad;
    [SerializeField] AudioClip hitOkay;
    [SerializeField] AudioClip hitPerfect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayJump(AudioSource audioSource)
    {
        audioSource.clip = jump;
        audioSource.Play();
    }

    public void PlayLand(AudioSource audioSource)
    {
        audioSource.clip = land;
        audioSource.Play();
    }

    public void PlayWallHit(AudioSource audioSource)
    {
        audioSource.clip = wallHit;
        audioSource.Play();
    }

    public void PlayPerfect(AudioSource audioSource)
    {
        audioSource.clip = hitPerfect;
        audioSource.Play();
    }

    public void PlayOkay(AudioSource audioSource)
    {
        audioSource.clip = hitOkay;
        audioSource.Play();
    }

    public void PlayBad(AudioSource audioSource)
    {
        audioSource.clip = hitBad;
        audioSource.Play();
    }
}
