using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Managers.CameraManager
{
    public class CameraFollow : MonoBehaviour
    {
        Transform FollowTarget;

        public float HeightDistance = 6;
        public float SmoothDampening = 0.3f;

        void Start()
        {
            FollowTarget = FindObjectOfType<Player>().transform;
        }

        void LateUpdate()
        {
            if (FollowTarget != null)
            {
                Vector3 cameraPosition = transform.position;
                Vector3 targetPosition = FollowTarget.position;

                float heightDifference = Math.Abs(cameraPosition.y - targetPosition.y);

                if (!(HeightDistance + 0.2f > heightDifference) || !(HeightDistance - 0.2f < heightDifference)) // if the min distance is passed.
                {
                    float nextFrameHeight = Mathf.Lerp(cameraPosition.y, targetPosition.y + HeightDistance, Time.deltaTime * SmoothDampening * (HeightDistance));

                    cameraPosition.y = nextFrameHeight;

                    transform.position = cameraPosition;
                }

            }
        }
    }
}
