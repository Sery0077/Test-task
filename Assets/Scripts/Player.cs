using Components;
using UnityEngine;

namespace Chars
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float xSpeed;
        [SerializeField] private float ySpeed;
        [SerializeField] private LayerCheck waterCheck;
        [SerializeField] private float airGravityScale;

        private bool _inWater;
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

        private void Update()
        {
            _inWater = waterCheck.IsTouching();
            _rigidbody.gravityScale = _inWater ? 0 : airGravityScale;
        }

        private void FixedUpdate()
        {
            var yVelocity = _rigidbody.velocity.y;

            if (_direction.y != 0 && _inWater)
            {
                yVelocity = CalculateYVelocity();
            }
            else if (_inWater)
            {
                yVelocity = 0.5f * _rigidbody.velocity.y;
            }

            var rotateAngle = yVelocity switch
            {
                > 45 => 45,
                < -45 => -45,
                _ => yVelocity * 2
            };

            transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);

            _rigidbody.velocity = new Vector2(xSpeed, yVelocity);
        }

        private float CalculateYVelocity()
        {
            return ySpeed * _direction.y;
            ;
        }
    }
}