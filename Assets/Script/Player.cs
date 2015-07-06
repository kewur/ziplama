using UnityEngine;
using System.Collections;
using Assets.Script.Managers.InputManager;
using Assets.Script.Utility;

namespace Assets.Script
{
    [RequireComponent(typeof(InputManager))]
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        public int HighScore = 0;

        public BoxCollider PlayerCollider = null;
        public Rigidbody PlayerRigidBody = null;
        public Animator PlayerAnimator = null;

        public float FlapEnergy = 2f;

        public float EnergyRecoveryCooldown = 0.5f;
        public float EnergyReplenishRate = 0.5f;

        public readonly float MaxEnergy = 100;

        public float _Energy = 100f;
        public float Energy
        {
            get { return _Energy; }
            set
            {
                if (_Energy == value)
                    return;

                _Energy = value;

                if(_Energy <= MaxEnergy)
                    StartCoroutine(ReplenishEnergy());
            }
        }

        private static Player _Instance = null;
        public static Player Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = FindObjectOfType<Player>();
                    if (Instance == null)
                        Debug.LogError("Player is not in the game.");
                }

                return _Instance;
            }
        }

        public float FlappingDragForce = 10f;
        public const float FallingDragForce = 1f;
        public float FlapUpwardsForce = 10f;



        // Use this for initialization
        void Awake()
        {
            PlayerCollider = GetComponent<BoxCollider>();
            PlayerRigidBody = GetComponent<Rigidbody>();
            PlayerAnimator = GetComponent<Animator>();


        }

        // Update is called once per frame
        void Update()
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            transform.rotation =  Quaternion.Euler(0, currentRotation.y, 0);

            Vector3 currentPosition = transform.position;

            if(currentPosition.x < InputManager.Instance.InputCoordinateFloor.LeftPosition.x)
                currentPosition.x = InputManager.Instance.InputCoordinateFloor.LeftPosition.x;

            if (currentPosition.x > InputManager.Instance.InputCoordinateFloor.RightPosition.x)
                currentPosition.x = InputManager.Instance.InputCoordinateFloor.RightPosition.x;

            if (currentPosition.z < InputManager.Instance.InputCoordinateFloor.BackPosition.z)
                currentPosition.z = InputManager.Instance.InputCoordinateFloor.BackPosition.z;

            if (currentPosition.z > InputManager.Instance.InputCoordinateFloor.FrontPosition.z)
                currentPosition.z = InputManager.Instance.InputCoordinateFloor.FrontPosition.z;

        }

        public void Flap(Vector3 direction)
        {
            StopCoroutine(ReplenishEnergy());

            PlayerAnimator.SetTrigger("Flap");
           // PlayerRigidBody.drag = FlappingDragForce;
            PlayerRigidBody.velocity = Vector3.zero;

            Vector3 lookAtLocation = direction;
            lookAtLocation.y = transform.position.y;


            transform.LookAt(lookAtLocation);

            Vector3 jumpTowards = direction - transform.position; // 
           // jumpTowards.z = 0;
            Debug.Log("Jump Towards" + jumpTowards);

          //  PlayerRigidBody.velocity = Vector3.zero;
            PlayerRigidBody.AddForce( (jumpTowards) * FlapUpwardsForce * Energy);
            PlayerRigidBody.AddForce(Vector3.up * FlapUpwardsForce * Energy);
            //Energy /= 2;
        }

        public void FlapEnd()
        {
            PlayerRigidBody.drag = FallingDragForce;
        }

        public IEnumerator ReplenishEnergy()
        {
            yield return new WaitForSeconds(EnergyRecoveryCooldown);

            while(Energy <= MaxEnergy)
            {
                yield return new WaitForSeconds(1f / EnergyReplenishRate);
                Energy++;
            }

            if (Energy >= MaxEnergy)
                Energy = MaxEnergy;

            yield break;
        }

    }
}
