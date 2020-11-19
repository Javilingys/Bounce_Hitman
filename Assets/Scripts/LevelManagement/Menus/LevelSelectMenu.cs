using BounceHitman.LevelManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MissionSelector))]
public class LevelSelectMenu : Menu<LevelSelectMenu>
{
    #region INSPECTOR
    [SerializeField]
    protected TextMeshProUGUI nameText;
    [SerializeField]
    protected Image previewImage;

    [SerializeField]
    protected float playDelay = 0.5f;
    [SerializeField]
    protected TransitionFader playTransitionPrefab;


    [Header("Lock System Objects")]
    [SerializeField]
    private Sprite lockStarSprite = null;
    [SerializeField]
    private Sprite unlockStarSprite = null;

    [SerializeField]
    private Image[] stars;

    [SerializeField]
    private GameObject unlockStarPanel = null;
    [SerializeField]
    private GameObject lockStarPanel = null;
    [SerializeField]
    private GameObject lockPanel = null;
    [SerializeField]
    private Button playButton = null;
    [SerializeField]
    protected TextMeshProUGUI lockStarText;
    #endregion

    #region PROTECTED
    protected MissionSelector missionSelector;
    protected MissionSpecs currentMission;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        missionSelector = GetComponent<MissionSelector>();
        UpdateInfo();
    }

    private void OnEnable()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        currentMission = missionSelector.GetCurrentMission();

        nameText.text = currentMission?.Name;
        previewImage.sprite = currentMission?.Image;
        previewImage.color = Color.white;

        if (MissionObjectList.Instance.IsEnoughtToUnlockLevel(currentMission.SceneName))
        {
            SetStarsPanel();
        }
        else
        {
            SetLockStarsPanel();
        }
    }

    private void SetLockStarsPanel()
    {
        lockPanel.SetActive(true);
        lockStarPanel.SetActive(true);
        unlockStarPanel.SetActive(false);
        playButton.enabled = false;

        lockStarText.text = $"{MissionObjectList.Instance.TotalStars}|{MissionObjectList.Instance.FindBySceneName(currentMission.SceneName).scoreForUnlock}";
    }

    private void SetStarsPanel()
    {
        lockPanel.SetActive(false);
        lockStarPanel.SetActive(false);
        unlockStarPanel.SetActive(true);
        playButton.enabled = true;
        switch (MissionObjectList.Instance.FindBySceneName(currentMission.SceneName).score)
        {
            case 1:
                SetOneStar();
                break;
            case 2:
                SetTwoStars();
                break;
            case 3:
                SetThreeStars();
                break;
            default:
                LockAllStars();
                break;
        }
    }

    public void SetOneStar()
    {
        LockAllStars();
        stars[0].sprite = unlockStarSprite;
    }

    public void SetTwoStars()
    {
        LockAllStars();
        for (int i = 0; i < stars.Length - 1; i++)
        {
            stars[i].sprite = unlockStarSprite;
        }
    }

    public void SetThreeStars()
    {
        LockAllStars();
        foreach (Image image in stars)
        {
            image.sprite = unlockStarSprite;
        }
    }

    public void LockAllStars()
    {
        foreach (Image image in stars)
        {
            image.sprite = lockStarSprite;
        }
    }

    public void OnNextPressed()
    {
        AudioManager.Instance.PlayPageSFX();
        missionSelector.IncrementIndex();
        UpdateInfo();
    }

    public void OnPreviousPressed()
    {
        AudioManager.Instance.PlayPageSFX();
        missionSelector.DecrementIndex();
        UpdateInfo();
    }

    public void OnPlayPressed()
    {
        CheatMaster.Instance.CheactDeactivated();
        DataManager.Instance.IncreaseCountToAd();
        AudioManager.Instance.PlayClickSFX();
        StartCoroutine(OnPlayPressedRoutine(currentMission?.SceneName));
    }

    private IEnumerator OnPlayPressedRoutine(string sceneName)
    {
        TransitionFader.PlayTransition(playTransitionPrefab);

        float fadeDelay = (playTransitionPrefab != null) ? playTransitionPrefab.Delay + playTransitionPrefab.FadeOnDuration
                : 0f;

        LevelLoader.LoadLevel(sceneName);
        yield return new WaitForSeconds(fadeDelay);
        MenuManager.Instance.CloseAllMenus();
        GameMenu.Open();
    }
}
