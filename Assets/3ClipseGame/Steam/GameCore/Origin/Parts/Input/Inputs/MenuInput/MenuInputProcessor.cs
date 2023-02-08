using System;
using UnityEngine;

namespace _3ClipseGame.Steam.GameCore.Origin.Parts.Input.Inputs.MenuInput
{
    public class MenuInputProcessor : InputProcessor
    {
        [SerializeField] private MenuInputHandler _menuInputHandler;

        public event Action ExitPressed;

        private bool _isExitPressed;

        private void Awake()
        {
            _menuInputHandler.ExitPressed += OnExitPressed;
        }

        public override void Enable()
        {
            _menuInputHandler.Enable();
        }

        public override void Disable()
        {
            _menuInputHandler.Disable();
        }

        private void OnExitPressed()
            => ExitPressed?.Invoke();
    }
}