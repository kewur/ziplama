using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Managers.InputManager
{
    public class InputPlane : MonoBehaviour
    {
        void LateUpdate()
        {
            float playerHeight = Player.Instance.transform.position.y;
            Vector3 currentPosition = transform.position;

            transform.position = new Vector3(currentPosition.x, playerHeight, currentPosition.z);
        }

    }
}
