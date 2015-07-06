using Assets.Scripts.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Terrain
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Mesh))]
    public class Floor : MonoBehaviourWF
    {

        public void Awake()
        {
            //DebugBoundCubes();
        }

        /// <summary>
        /// BottomLeft Screen is 0,0. TopRight is 1,1.
        /// </summary>
        /// <param name="viewPortCords"></param>
        /// <returns>Null if it's off screen.</returns>
        public Vector3? ViewPortToWorldCoordinates(Vector3 viewPortCords)
        {
            if (viewPortCords.x < 0 || viewPortCords.y < 0)
                return null;

            Vector3 worldCords = Vector3.zero;

            worldCords.x = Mathf.Lerp(TopRightBackPosition.x, TopLeftFrontPosition.x, viewPortCords.x);
            worldCords.y = viewPortCords.y;
            worldCords.z = Mathf.Lerp(TopRightBackPosition.z, TopLeftFrontPosition.z, viewPortCords.y);

            var dbg = new GameObject("inputPlace");


            return worldCords;
        }

    }
}
