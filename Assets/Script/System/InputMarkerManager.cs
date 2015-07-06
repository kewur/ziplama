using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.System
{
    public class InputMarkerManager : MonoBehaviour
    {
        private static InputMarkerManager _Instance;
        private static InputMarkerManager Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = FindObjectOfType<InputMarkerManager>();

                return _Instance;
            }
        }

        private float _MarkerDuration = 0.4f;
        public static float MarkerDuration
        {
            get { return Instance._MarkerDuration; }

        }

        private float _MarkerScaleRate = 1.05f;
        public static float MarkerScaleRate
        {
            get { return Instance._MarkerScaleRate; }
        }

        /// <summary>
        /// Marker prefab to create everytime.
        /// </summary>
        public GameObject InputMarkerPrefab;

        public static GameObject CreateInputMarker(Vector3? position)
        {
            if (!position.HasValue)
                return null;

            GameObject newMarker = (GameObject)Instantiate(Instance.InputMarkerPrefab, position.Value, Quaternion.identity);
            return newMarker;
        }


    }
}
