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
            //PlayerPrefs.SetFloat("MasterVolume", volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            if (DataManager.Instance != null)
            {
                DataManager.Instance.SfxVolume = volume;
            }
            //PlayerPrefs.SetFloat("SFXVolume", volume);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (DataManager.Instance != null)
            {
                DataManager.Instance.MusicVolume = volume;
            }
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
            //masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
            //sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
            //musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}