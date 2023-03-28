using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//使用静态类生成实例
public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource audioSource;
    [SerializeField] private AudioClip bonusAudio, hurtAudio, loseAudio;
    private void Awake()
    {
        instance = this;
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    public void BonusAudio()
    {
        audioSource.clip = bonusAudio;
        audioSource.Play();
    }

    public void HurtAudio()
    {
        audioSource.clip = hurtAudio;
        audioSource.Play();
    }

    public void LoseAudio()
    {
        audioSource.clip = loseAudio;
        audioSource.Play();
    }
}
