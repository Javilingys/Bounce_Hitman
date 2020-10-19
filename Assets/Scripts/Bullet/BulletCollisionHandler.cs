using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 dirNormal = collision.contacts[0].normal;

        Vector3 dir = Vector3.Reflect(transform.right, dirNormal);

        transform.right = dir;
    }

}
