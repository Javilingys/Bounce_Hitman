using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioManager))]
public class AudioPlayer : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]
    private Sound[] musicSounds;
    [SerializeField]
    private Sound[] enemyScreamSounds;
    [SerializeField]
    private Sound[] sfxSounds;

    private void Awake()
    {
        audioManager = GetComponent<AudioManager>();
        InitSounds();
    }

    private void InitSounds()
    {
        for (int i = 0; i < musicSounds.Length; i++)
        {
            GameObject go = new GameObject($"MusicSound_{i}_{musicSounds[i].clipName}");
            go.transform.SetParent(this.transform);
            musicSounds[i].SetSource(go.AddComponent<AudioSource>());
        }
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            GameObject go = new GameObject($"SFXSound_{i}_{sfxSounds[i].clipName}");
            go.transform.SetParent(this.transform);
            sfxSounds[i].SetSource(go.AddComponent<AudioSource>());
        }
        for (int i = 0; i < enemyScreamSounds.Length; i++)
        {
            GameObject go = new GameObject($"ScreamSound_{i}_{enemyScreamSounds[i].clipName}");
            go.transform.SetParent(this.transform);
            enemyScreamSounds[i].SetSource(go.AddComponent<AudioSource>());
        }
    }

    public void PlayRandomMusic()
    {
        int randomIndex = Random.Range(0, musicSounds.Length);

        musicSounds[randomIndex].Play();

        Invoke(nameof(PlayRandomMusic), musicSounds[randomIndex].clip.length);
    }

    public void PlayRandomEnemyScream()
    {
        int randomIndex = Random.Range(0, enemyScreamSounds.Length);

        enemyScreamSounds[randomIndex].Play();
    }

    public void PlaySFX(string name)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if (sfxSounds[i].clipName == name)
            {
                sfxSounds[i].Play();
                return;
            }
        }
    }

    public void StopSFX(string name)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if (sfxSounds[i].clipName == name)
            {
                sfxSounds[i].Stop();
                return;
            }
        }
    }
}
