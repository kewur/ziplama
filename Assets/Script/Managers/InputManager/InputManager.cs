using Assets.Script.System;
using Assets.Script.Terrain;
using Assets.Script.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.Managers.InputManager
{
    public class InputManager : MonoBehaviour
    {

        private BoxCollider _InputPlaneCollider = null;

        private Floor _InputCoordinateFloor = null;
        public Floor InputCoordinateFloor
        {
            get
            {
                if (_InputCoordinateFloor == null)
                {
                    Debug.LogWarning("The Floor to project input coordinates is null, attempting to find one at random.");
                    try
                    {
                        _InputCoordinateFloor = FindObjectOfType<Floor>();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Floor could not be found.");
                    }
                }

                return _InputCoordinateFloor;
            }
        }

        float lastMouseclickDelta = float.MinValue;
        public float DoubleTapTime = 0.7f;

        private static InputManager _Instance = null;
        public static InputManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = FindObjectOfType<InputManager>();

                    if (_Instance == null)
                        _Instance = Player.Instance.gameObject.AddComponent<InputManager>();

                }

                return _Instance;
            }
        }


        void Awake()
        {
#if UNITY_EDITOR || UNITY_PLAYER
            InitializeInputCollider();
#endif
        }

        void Update()
        {
            Vector3? flapPosition = null;


#if UNITY_IPHONE
              if(Input.touchCount > 0)
                foreach(var t in Input.touches)
                    if(t.tapCount > 1)
                        Vector3 flapPosition = Camera.main.ScreenToViewportPoint(t.position);

#else
            if (Input.GetMouseButtonUp(0))
            {
                if (Time.deltaTime - lastMouseclickDelta < DoubleTapTime)
                {
                    Ray flapRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit hitinfo;
                    if (Physics.Raycast(flapRay, out hitinfo, float.MaxValue, Layers.InputLayerMask))
                        flapPosition = hitinfo.point;

                    if (flapPosition.HasValue)
                        lastMouseclickDelta = float.MinValue;
                }
                else
                    lastMouseclickDelta = Time.deltaTime;
            }

#endif

            if (flapPosition.HasValue) //if there was an input this will have a value.
            {
                Debug.Log(string.Format("position: XY: {0}, {1}, {2}", flapPosition.Value.x, flapPosition.Value.y, flapPosition.Value.z));

                Player.Instance.Flap(flapPosition.Value);
                Vector3 markerPosition = flapPosition.Value;
                markerPosition.y = Player.Instance.transform.position.y;

#if UNITY_IPHONE
                InputMarkerManager.CreateInputMarker(InputCoordinateFloor.ViewPortToWorldCoordinates(markerPosition));

#else
                InputMarkerManager.CreateInputMarker(markerPosition);
#endif
            }

        }

        private void InitializeInputCollider()
        {
            GameObject inputPlane = new GameObject("Input Plane");

            inputPlane.transform.localScale = InputManager.Instance.InputCoordinateFloor.transform.localScale;
            //inputPlane.transform.parent = this.transform;
            inputPlane.transform.localPosition = Vector3.zero;
            inputPlane.layer = Layers.InputLayer;

            
            _InputPlaneCollider = inputPlane.AddComponent<BoxCollider>();
            _InputPlaneCollider.gameObject.AddComponent<InputPlane>();


            _InputPlaneCollider.isTrigger = true;

        }

    }

}
