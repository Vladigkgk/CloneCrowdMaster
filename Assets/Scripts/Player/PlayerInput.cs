using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private CloneCrowdMaster _input;

        public Vector2 Diration { get; private set; }
        public event UnityAction Started;
        public event UnityAction Canceled;

        private void Awake()
        {
            _input = new CloneCrowdMaster();        
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Fire.started += OnStarted;
            _input.Player.Fire.canceled += OnCanceled;
        }

        private void FixedUpdate()
        {
            Diration = _input.Player.Move.ReadValue<Vector2>();
        }

        private void OnStarted(InputAction.CallbackContext contex)
        {
            Started?.Invoke();
        }

        private void OnCanceled(InputAction.CallbackContext context)
        {
            Canceled?.Invoke();
        } 

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}