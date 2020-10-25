using System;
using UnityEngine;

namespace BounceHitman.Misc
{
    [RequireComponent(typeof(Collider2D))]
    public class PlacingZone : MonoBehaviour
    {
        public static Action<Vector3> onTriggerExitEvent;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(Tags.PLAYER_TAG))
            {
                Vector3 exitPosition = collision.gameObject.transform.position;
                onTriggerExitEvent?.Invoke(exitPosition);
            }
        }
    }
}