using Components;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chars
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float xSpeed;
        [SerializeField] private float ySpeed;
        [SerializeField] private LayerCheck waterCheck;
        [SerializeField] private float airGravityScale;
        [SerializeField] private float secondsToDieInAir;

        private bool _inWater;
        private Vector2 _direction;
        private Rigidbody2D _rigidbody;

        private float _secondsInAir = 0;

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

            _secondsInAir = _inWater ? 0 : _secondsInAir + Time.deltaTime;

            if (_secondsInAir > secondsToDieInAir)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void FixedUpdate()
        {
            var yVelocity = CalculateYVelocity(_rigidbody.velocity.y);
            var xVelocity = CalculateXVelocity(_rigidbody.velocity.x);

            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            RotateSprite(yVelocity);
        }

        private void RotateSprite(float yVelocity)
        {
            var rotateAngle = yVelocity switch
            {
                > 45 => 45,
                < -45 => -45,
                _ => yVelocity * 2
            };

            transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        }

        private float CalculateYVelocity(float currentYVelocity)
        {
            if (!_inWater) return currentYVelocity;
            if (_direction.y != 0)
            {
                return ySpeed * _direction.y;
            }

            return 0.5f * _rigidbody.velocity.y;
        }

        private float CalculateXVelocity(float currentXVelocity)
        {
            return _inWater ? xSpeed : currentXVelocity;
        }
    }
}