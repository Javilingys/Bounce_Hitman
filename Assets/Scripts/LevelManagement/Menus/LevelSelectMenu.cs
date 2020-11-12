using BounceHitman.LevelManagement;
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
    }

    public void OnNextPressed()
    {
        missionSelector.IncrementIndex();
        UpdateInfo();
    }

    public void OnPreviousPressed()
    {
        missionSelector.DecrementIndex();
        UpdateInfo();
    }

    public void OnPlayPressed()
    {
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
