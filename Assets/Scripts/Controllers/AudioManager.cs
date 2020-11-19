using BounceHitman.Misc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioPlayer))]
public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    private bool isBackgroundMusicStarted = false;
    public bool IsBackgroundMusicStarted { get => isBackgroundMusicStarted; set => isBackgroundMusicStarted = value; }

    public AudioMixer audioMixer;

    private AudioPlayer audioPlayer;

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            audioPlayer = GetComponent<AudioPlayer>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetMasterVolume(float masterLv)
    {
        audioMixer.SetFloat("masterVolume", masterLv);
    }

    public void SetSFXVolume(float sfxLv)
    {
        audioMixer.SetFloat("sfxVolume", sfxLv);
    }

    public void SetMusicVolume(float musicLv)
    {
        audioMixer.SetFloat("musicVolume", musicLv);
    }

    public void PlayMusic()
    {
        audioPlayer.PlayRandomMusic();
    }

    public void PlayBloodSFX()
    {
        audioPlayer.PlaySFX("Blood");
    }

    public void PlayReloadSFX()
    {
        audioPlayer.PlaySFX("Reload");
    }

    public void PlayShootSFX()
    {
        audioPlayer.PlaySFX("Shoot");
    }

    public void PlayEnemyScreamSFX()
    {
        audioPlayer.PlayRandomEnemyScream();
    }

    public void PlayBounceSFX()
    {
        audioPlayer.PlaySFX("BulletBounce");
    }

    public void PlayExplosionSFX()
    {
        audioPlayer.PlaySFX("Explosion");
    }

    public void PlayBulletLaunchSFX()
    {
        audioPlayer.PlaySFX("BulletLaunch");
    }

    public void StopBulletLaunchSFX()
    {
        audioPlayer.StopSFX("BulletLaunch");
    }

    public void PlayClickSFX()
    {
        audioPlayer.PlaySFX("Click");
    }

    public void PlayPageSFX()
    {
        audioPlayer.PlaySFX("PageTurn");
    }
}
