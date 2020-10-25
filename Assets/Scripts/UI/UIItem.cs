using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.UI
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] UIType uIType;

        public UIType UIType
        {
            get => uIType;
        }
    }
}