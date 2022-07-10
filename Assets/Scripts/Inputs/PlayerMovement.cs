using System;
using UnityEngine;

namespace TheGame.Inputs
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private Animator _animator;

        [SerializeField] private float _moveSpeed;

        public Action<bool> IsPlayerMoving;

        private void FixedUpdate()
        {

            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y,
                _joystick.Vertical * _moveSpeed);
            
            float mag = Mathf.Clamp01(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).magnitude);  

            if (mag > 0 && mag < 0.7f)
            {
                _animator.SetBool("isWalking", true);
                _animator.SetBool("isRunning", false);
            }
            else if (mag >= 0.7f)
            {
                _animator.SetBool("isRunning", true);
                _animator.SetBool("isWalking", false);
            }
            else
            {
                
                _animator.SetBool("isRunning", false);
                _animator.SetBool("isWalking", false);
            }
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
                IsPlayerMoving?.Invoke(true);
            } else
            {
                IsPlayerMoving?.Invoke(false);
            }
        }
    }
}
