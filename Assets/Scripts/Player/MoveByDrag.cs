using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByDrag : MonoBehaviour
{
    #region Unity Functions
    #endregion

    #region Public Functions
    public void Move(Vector3 targetPosition)
    {
        transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
    }
    #endregion

    #region Private Functions
    #endregion
}
