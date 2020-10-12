using UnityEngine;

public class RotatorByDrag : MonoBehaviour
{
    [SerializeField]
    private Transform objectForRotation = null;

    #region Unity Functions
    private void Update()
    {

    }
    #endregion

    #region Public Functions
    private void Rotate(Vector3 targetPosition, bool isOpositeDirection = false)
    {
        if (!objectForRotation) return;

        Vector3 dir = isOpositeDirection ? objectForRotation.position - targetPosition : targetPosition - objectForRotation.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        objectForRotation.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    #endregion

    #region Private Functions

    #endregion
}
