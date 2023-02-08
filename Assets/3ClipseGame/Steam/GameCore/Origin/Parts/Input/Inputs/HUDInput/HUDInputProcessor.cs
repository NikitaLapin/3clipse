using System;
using System.Collections;
using UnityEngine;

namespace _3ClipseGame.Steam.GameCore.Origin.Parts.Input.Inputs.HUDInput
{
    public class HUDInputProcessor : InputProcessor
    {
        [SerializeField] private HUDInputHandler _hudInputHandler;
        
        public bool GetIsShowWheel() => _isShowWheel;
        public event Action ToggleMenu;
        

        private bool _isShowWheel;

        private void Awake()
        {
            _hudInputHandler.ShowWheelChanged += OnShowWheelChanged;
            _hudInputHandler.ToggleMainMenuPressed += OnToggleMainMenuPressed;
        }

        public override void Enable()
        {
            _hudInputHandler.Enable();
        }

        public override void Disable()
        {
            _hudInputHandler.Disable();
        }

        private void OnShowWheelChanged(bool isVisible)
            => _isShowWheel = isVisible;

        private void OnToggleMainMenuPressed()
            => ToggleMenu?.Invoke();
    }
}
