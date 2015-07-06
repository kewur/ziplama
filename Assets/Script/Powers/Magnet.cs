using Assets.Script.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Powers
{
    public class Magnet : MonoBehaviour
    {
        [Range(1, 2.5f)]
        public float Distance = 2f;
        public float Force = 1f;

        CapsuleCollider MagnetCollider = null;

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == Tags.Coin)
            {

            }

        }

        public void Start()
        {
            if (GetComponentInChildren<Collider>() == null)
            {
                MagnetCollider = gameObject.AddComponent<CapsuleCollider>();
                MagnetCollider.isTrigger = true;
            }

            ///Set the collider height
            MagnetCollider.center = Player.Instance.PlayerCollider.center;
            MagnetCollider.radius = Player.Instance.PlayerCollider.size.z  * Distance;
            MagnetCollider.height = Player.Instance.PlayerCollider.size.y * Distance;


        }




    }
}
