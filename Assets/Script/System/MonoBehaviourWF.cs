using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.System
{
    public class MonoBehaviourWF : MonoBehaviour
    {
        #region Extent Positions

        /// <summary>
        /// If the object is static, it's safe to assume that it won't move, so cache the values once gotten for performance.
        /// </summary>
        private Vector3? _StaticTopPosition = null;
        /// <summary>
        /// Returns top coordinate of the GameObject.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public Vector3 TopPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopPosition.HasValue)
                    return _StaticTopPosition.Value;

                Bounds bounds = GetBounds();
                Vector3 val = this.transform.position + (Vector3.up * bounds.extents.y);

                if (gameObject.isStatic)
                    _StaticTopPosition = val;

                return val;
            }
        }

        private Vector3? _StaticBottomPosition = null;
        public Vector3 BottomPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticBottomPosition.HasValue)
                    return _StaticBottomPosition.Value;

                Bounds bounds = GetBounds();
                Vector3 val = this.transform.position - (Vector3.up * bounds.extents.y);

                if (gameObject.isStatic)
                    _StaticBottomPosition = val;

                return val;
            }
        }

        private Vector3? _StaticCenterPosition = null;
        public Vector3 CenterPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticCenterPosition.HasValue)
                    return _StaticCenterPosition.Value;

                Bounds bounds = GetBounds();
                Vector3 val = bounds.center;

                if (gameObject.isStatic)
                    _StaticCenterPosition = val;

                return val;
            }
        }

        private Vector3? _StaticFrontPosition = null;
        public Vector3 FrontPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticFrontPosition.HasValue)
                    return _StaticFrontPosition.Value;

                Bounds bounds = GetBounds();
                Vector3 val = this.CenterPosition + this.transform.forward * bounds.extents.z;

                if (gameObject.isStatic)
                    _StaticFrontPosition = val;

                return val;
            }
        }

        private Vector3? _StaticBackPosition = null;
        public Vector3 BackPosition
        {
            get
            {

                if (gameObject.isStatic && _StaticBackPosition.HasValue)
                    return _StaticBackPosition.Value;

                Bounds bounds = GetBounds();
                Vector3 val = this.CenterPosition - this.transform.forward * bounds.extents.z;

                if (gameObject.isStatic)
                    _StaticBackPosition = val;

                return val;
            }
        }

        private Vector3? _StaticRightPosition = null;
        public Vector3 RightPosition
        {
            get
            {

                if (gameObject.isStatic && _StaticRightPosition.HasValue)
                    return _StaticRightPosition.Value;

                Bounds bounds = GetBounds();
                Vector3 val = this.CenterPosition - (Vector3.right * bounds.extents.x);

                if (gameObject.isStatic)
                    _StaticRightPosition = val;

                return val;
            }
        }

        private Vector3? _StaticLeftPosition = null;
        public Vector3 LeftPosition
        {
            get
            {

                if (gameObject.isStatic && _StaticLeftPosition.HasValue)
                    return _StaticLeftPosition.Value;

                Bounds bounds = GetBounds();
                Vector3 val = this.CenterPosition + (Vector3.right * bounds.extents.x);

                if (gameObject.isStatic)
                    _StaticLeftPosition = val;

                return val;
            }
        }

        private Vector3? _StaticTopLeftPosition = null;
        public Vector3 TopLeftPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopLeftPosition.HasValue)
                    return _StaticTopLeftPosition.Value;

                var val = new Vector3(LeftPosition.x, TopPosition.y, CenterPosition.z);

                if (gameObject.isStatic)
                    _StaticTopLeftPosition = val;

                return val;
            }
        }

        private Vector3? _StaticTopLeftFrontPosition = null;
        public Vector3 TopLeftFrontPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopLeftFrontPosition.HasValue)
                    return _StaticTopLeftFrontPosition.Value;

                var val = new Vector3(LeftPosition.x, TopPosition.y, FrontPosition.z);

                if (gameObject.isStatic)
                    _StaticTopLeftFrontPosition = val;

                return val;
            }
        }

        private Vector3? _StaticTopRightFrontPosition = null;
        public Vector3 TopRightFrontPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopRightFrontPosition.HasValue)
                    return _StaticTopRightFrontPosition.Value;

                var val = new Vector3(RightPosition.x, TopPosition.y, FrontPosition.z);

                if (gameObject.isStatic)
                    _StaticTopRightFrontPosition = val;

                return val;
            }
        }

        private Vector3? _StaticTopFrontPosition = null;
        public Vector3 TopFrontPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopFrontPosition.HasValue)
                    return _StaticTopFrontPosition.Value;

                var val = new Vector3(CenterPosition.x, TopPosition.y, FrontPosition.z);

                if (gameObject.isStatic)
                    _StaticTopFrontPosition = val;

                return val;
            }
        }

        private Vector3? _StaticTopBackPosition = null;
        public Vector3 TopBackPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopBackPosition.HasValue)
                    return _StaticTopBackPosition.Value;

                var val = new Vector3(CenterPosition.x, TopPosition.y, BackPosition.z);

                if (gameObject.isStatic)
                    _StaticTopBackPosition = val;

                return val;

            }
        }

        private Vector3? _StaticTopRightBackPosition = null;
        public Vector3 TopRightBackPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopRightBackPosition.HasValue)
                    return _StaticTopRightBackPosition.Value;

                var val = new Vector3(RightPosition.x, TopPosition.y, BackPosition.z);

                if (gameObject.isStatic)
                    _StaticTopRightBackPosition = val;

                return val;
            }
        }

        private Vector3? _StaticTopLeftBackPosition = null;
        public Vector3 TopLeftBackPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopLeftBackPosition.HasValue)
                    return _StaticTopLeftBackPosition.Value;

                var val = new Vector3(LeftPosition.x, TopPosition.y, BackPosition.z);

                if (gameObject.isStatic)
                    _StaticTopLeftBackPosition = val;

                return val;
            }
        }

        private Vector3? _StaticTopRightPosition = null;
        public Vector3 TopRightPosition
        {
            get
            {
                if (gameObject.isStatic && _StaticTopRightPosition.HasValue)
                    return _StaticTopRightPosition.Value;

                var val = new Vector3(RightPosition.x, TopPosition.y, CenterPosition.z);

                if (gameObject.isStatic)
                    _StaticTopRightPosition = val;

                return val;

            }
        }

        #endregion

        private Vector3? _StaticBoundsSize = null;
        public Vector3 BoundsSize
        {
            get
            {
                if (gameObject.isStatic && _StaticBoundsSize.HasValue)
                    return _StaticBoundsSize.Value;

                Bounds bounds = this.GetBounds();
                var size = bounds.size;
                _StaticBoundsSize = size;

                return size;
            }
        }


        public Bounds GetBounds()
        {
            Mesh mesh = this.GetComponent<Mesh>();
            if (mesh != null)
                return mesh.bounds;
            Collider collider = this.GetComponent<Collider>();
            if (collider != null)
                return collider.bounds;

            Bounds sizeBound = new Bounds(gameObject.transform.position, this.transform.lossyScale);
            return sizeBound;
        }

        #region Debug Functions

        protected void DebugBoundCubes()
        {
            GameObject boundCubesContainer = new GameObject("Bound Cubes");
            boundCubesContainer.transform.parent = this.transform;
            boundCubesContainer.transform.localPosition = Vector3.zero;


            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = CenterPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Center";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = RightPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Right";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = LeftPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Left";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = BottomPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Bottom";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = FrontPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Front";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = BackPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Back";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopLeftFrontPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top Left Front";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopRightFrontPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top Right Front";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopFrontPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top Front";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopBackPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top Back";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopRightBackPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top Right Back";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopLeftBackPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top Left Back";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopRightPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top Right";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = TopLeftPosition;
                cube.transform.parent = boundCubesContainer.transform;
                cube.name = "Top Left";
                cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

         
        }

        #endregion

    }
}
