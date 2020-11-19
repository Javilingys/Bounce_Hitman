using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BounceHitman.Misc;

public class TutorialCanvas : SingletonMonoBehaviour<TutorialCanvas>
{
    [SerializeField]
    private GameObject placeInfoPanel;
    [SerializeField]
    private GameObject aimInfoPanel;

    public void ShowPlaceInfoPanel()
    {
        HideAllPanels();
        placeInfoPanel.SetActive(true);
    }

    public void ShowAimInfoPanel()
    {
        HideAllPanels();
        aimInfoPanel.SetActive(true);
    }

    public void HideAllPanels()
    {
        if (placeInfoPanel.activeInHierarchy == true)
        {
            placeInfoPanel.SetActive(false);
        }

        if (aimInfoPanel.activeInHierarchy == true)
        {
            aimInfoPanel.SetActive(false);
        }
    }
}
