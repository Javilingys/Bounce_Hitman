using BounceHitman.Misc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BounceHitman.UI
{
    public enum UIType
    {
        GameUI,
        EndScreen
    }

    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        private List<UIItem> uiItemlList;
        private UIItem lastActiveUIItem;

        protected override void Awake()
        {
            base.Awake();
            uiItemlList = GetComponentsInChildren<UIItem>().ToList();
            uiItemlList.ForEach((x) => x.gameObject.SetActive(false));
            SwitchUI(UIType.GameUI);
        }

        public void SwitchUI(UIType uIType)
        {
            if (lastActiveUIItem != null)
            {
                lastActiveUIItem.gameObject.SetActive(false);
            }

            UIItem desiredUIItem = uiItemlList.Find(x => x.UIType == uIType);
            if (desiredUIItem != null)
            {
                desiredUIItem.gameObject.SetActive(true);
                lastActiveUIItem = desiredUIItem;
            }
            else
            {
                Debug.LogWarning("The desired UI Item not found!");
            }
        }
    }
}