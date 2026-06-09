using Input;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
    
        private Rigidbody2D _rb;
        private Vector2 _moveInput;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            InputManager.moveAction += HandleMove;
        }

        private void OnDisable()
        {
            InputManager.moveAction -= HandleMove;
        }

        private void FixedUpdate()
        {
            Move(_moveInput);
        }

        private void HandleMove(Vector2 direction)
        {
            _moveInput = direction.normalized;
        }

        private void Move(Vector2 direction)
        {
            _rb.MovePosition(_rb.position + direction * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}
