using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab = null;
    [SerializeField]
    private Transform positionToInstance = null;

    public void InstantiateBullet()
    {
        Instantiate(bulletPrefab, positionToInstance.position, positionToInstance.rotation);
    }
}
