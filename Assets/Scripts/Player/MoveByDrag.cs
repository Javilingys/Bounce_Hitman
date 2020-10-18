using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveByDrag : MonoBehaviour
{
    [SerializeField]
    private float currentMinX = 0f;
    [SerializeField]
    private float currentMaxX = 0f;

    #region Unity Functions
    #endregion

    #region Public Functions
    public void Move(Vector3 targetPosition)
    {
        float currentX = Mathf.Clamp(targetPosition.x, currentMinX, currentMaxX);
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }
    #endregion

    #region Private Functions

    #endregion
}
