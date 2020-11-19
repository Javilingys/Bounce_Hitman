using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BounceHitman.LevelManagement
{
    public class SettingsMenu : Menu<SettingsMenu>
    {
        [SerializeField]
        private Slider masterVolumeSlider;

        [SerializeField]
        private Slider sfxVolumeSlider;

        [SerializeField]
        private Slider musicVolumeSlider;

        //private DataManager dataManager;

        protected override void Awake()
        {
            base.Awake();

            //dataManager = FindObjectOfType<DataManager>();

            LoadData();
        }

        private void Start()
        {
            LoadData();
        }

        public void OnMasterVolumeChanged(float volume)
        {
            if (DataManager.Instance != null)
            {
                DataManager.Instance.MasterVolume = volume;
            }
            AudioManager.Instance.SetMasterVolume(volume);
            //PlayerPrefs.SetFloat("MasterVolume", volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            if (DataManager.Instance != null)
            {
                DataManager.Instance.SfxVolume = volume;
            }
            AudioManager.Instance.SetSFXVolume(volume);
            //PlayerPrefs.SetFloat("SFXVolume", volume);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (DataManager.Instance != null)
            {
                DataManager.Instance.MusicVolume = volume;
            }
            AudioManager.Instance.SetMusicVolume(volume);
            //PlayerPrefs.SetFloat("MusicVolume", volume);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            if (DataManager.Instance != null)
            {
                DataManager.Instance.Save();
            }
            //PlayerPrefs.Save();
        }

        public void LoadData()
        {
            if (DataManager.Instance == null || masterVolumeSlider == null || sfxVolumeSlider == null
                || musicVolumeSlider == null) 
                return;

            DataManager.Instance.Load();

            masterVolumeSlider.value = DataManager.Instance.MasterVolume;
            sfxVolumeSlider.value = DataManager.Instance.SfxVolume;
            musicVolumeSlider.value = DataManager.Instance.MusicVolume;

            AudioManager.Instance.SetMasterVolume(DataManager.Instance.MasterVolume);
            AudioManager.Instance.SetSFXVolume(DataManager.Instance.SfxVolume);
            AudioManager.Instance.SetMusicVolume(DataManager.Instance.MusicVolume);
        }
    }
}