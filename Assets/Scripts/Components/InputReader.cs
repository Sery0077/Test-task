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

        void Start()
        {
            EnhancedTouchSupport.Enable();
            TouchSimulation.Enable();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            Debug.Log(Touchscreen.current.touches.Count);
            var direction = context.ReadValue<Vector2>();
            player.SetDirection(direction);
        }

        private void Update()
        {
        #if UNITY_ANDROID
            player.SetDirection(Touch.activeFingers.Count > 0 ? Vector2.up : Vector2.down);
        #endif
        }
    }
}