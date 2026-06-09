using Input;
using UnityEngine;

namespace Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private static readonly int XInput = Animator.StringToHash("XInput");
        private static readonly int YInput = Animator.StringToHash("YInput");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private Animator _animator;

        private Vector2 _lastDirection = Vector2.down;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            InputManager.moveAction += HandleAnimation;
        }

        private void OnDisable()
        {
            InputManager.moveAction -= HandleAnimation;
        }

        private void HandleAnimation(Vector2 direction)
        {
            bool isMoving = direction != Vector2.zero;

            if (isMoving)
            {
                _lastDirection = direction;
            }

            _animator.SetBool(IsMoving, isMoving);
            _animator.SetFloat(XInput, _lastDirection.x);
            _animator.SetFloat(YInput, _lastDirection.y);
        }
    }
}