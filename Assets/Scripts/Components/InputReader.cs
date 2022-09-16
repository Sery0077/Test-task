using Chars;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Components
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private Player player;

        private void OnDisable()
        {
            EnhancedTouchSupport.Disable();
            TouchSimulation.Disable();
        }

        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            TouchSimulation.Enable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            player.SetDirection(direction);
        }

        void Update()
        {
        #if UNITY_ANDROID
            player.SetDirection(Touch.activeFingers.Count > 0 ? Vector2.up : Vector2.down);
        #endif
        }
    }
}