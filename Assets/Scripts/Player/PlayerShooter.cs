using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab = null;

    [SerializeField]
    private Transform positionToInstance = null;

    private Bullet bulletInstance = null;

    public void InstantiateBullet()
    {
        bulletInstance = Instantiate(bulletPrefab, positionToInstance.position, positionToInstance.rotation);
    }

    public Transform GetBulletTransform()
    {
        return bulletInstance.gameObject.transform;
    }
}
