using Chars;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Components
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private Player player;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            player.SetDirection(direction);
        }
    }
}