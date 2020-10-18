using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceHitman.Player
{
    [RequireComponent(typeof(LineRenderer))]
    public class AimRenderer : MonoBehaviour
    {
        [SerializeField]
        private Transform aim;
        [SerializeField]
        private float laserDistance = 100;
        [SerializeField]
        private int reflections = 5;

        private LineRenderer laserRenderer = null;
        private Vector3 pos = new Vector3();
        private Vector3 dir = new Vector3();

        bool loopActive = true;

        private void Awake()
        {
            laserRenderer = GetComponent<LineRenderer>();
        }

        public void SetLine()
        {
            CastRay(aim.transform.position, aim.transform.right);
        }

        private void CastRay(Vector3 position, Vector3 direction)
        {
            loopActive = true;
            int countLaser = 1;

            pos = position;
            dir = direction;

            laserRenderer.positionCount = countLaser;
            laserRenderer.SetPosition(0, pos);

            while (loopActive)
            {
                RaycastHit2D hit = Physics2D.Raycast(pos, dir, laserDistance);
                if (hit)
                {
                     countLaser++;
                     laserRenderer.positionCount = countLaser;
                     dir = Vector3.Reflect(dir, hit.normal);
                     pos = (Vector2)dir.normalized + hit.point;
                     laserRenderer.SetPosition(countLaser - 1, hit.point);

                }
                else
                {
                    countLaser++;
                    laserRenderer.positionCount = countLaser;
                    laserRenderer.SetPosition(countLaser - 1, pos + (dir.normalized * laserDistance));
                    loopActive = false;
                }
                if (countLaser > reflections)
                {
                    loopActive = false;
                }
            }
        }

        public void ClearLine()
        {
            loopActive = false;
            laserRenderer.positionCount = 0;
        }
    }
}