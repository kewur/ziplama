using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.System
{
    public class InputMarker : MonoBehaviour
    {
        public void Awake()
        {
            Destroy(gameObject, InputMarkerManager.MarkerDuration);
        }

        void FixedUpdate()
        {
            transform.localScale = transform.localScale * InputMarkerManager.MarkerScaleRate;
        }
    }
}
