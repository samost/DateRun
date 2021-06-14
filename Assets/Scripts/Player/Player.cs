using System;
using Systems;
using Obstacle;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float Speed;
        [SerializeField] private float SpeedRotation;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        
        protected void Move()
        {
            if (Joystick.tap)
            {
                _rigidbody.AddForce(Speed * Joystick.MoveDirection, ForceMode.VelocityChange);

                Quaternion lookRotation =
                    Joystick.MoveDirection != Vector3.zero ? Quaternion.LookRotation(Joystick.MoveDirection) : transform.rotation;
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * SpeedRotation);
                
                AnimatorManager.Instance.SetGirlAnimation(TypeAnimation.Walk, true);
                AnimatorManager.Instance.SetManAnimation(TypeAnimation.Walk, true);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * SpeedRotation);
                
                AnimatorManager.Instance.SetGirlAnimation(TypeAnimation.Walk, false);
                AnimatorManager.Instance.SetManAnimation(TypeAnimation.Walk, false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var q = other.GetComponent<InteractionObstacle>();
            if (q != null)
            {
                q.Action();   
            }
        }

        private void FixedUpdate()
        {
            Move();
        }
    }
}