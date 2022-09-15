using UnityEngine;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float xSpeed;
        [SerializeField] private float ySpeed;

        private Vector2 _direction;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            var yVelocity = _direction.y * ySpeed;
            _rigidbody.velocity = new Vector2(xSpeed, yVelocity);
        }
    }
}