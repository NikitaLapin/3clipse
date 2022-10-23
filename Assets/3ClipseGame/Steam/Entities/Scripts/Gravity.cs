using _3ClipseGame.Steam.Entities.Player.Scripts.PlayerMoverScripts;
using _3ClipseGame.Steam.Entities.Scripts.CharacterMover;
using UnityEngine;
using CharacterController = _3ClipseGame.Steam.Entities.Scripts.CustomController.CharacterController;

namespace _3ClipseGame.Steam.Entities.Scripts
{
    public class Gravity : MonoBehaviour
    {
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float gravityLimit = -30f;
        
        private CharacterController _controller;
        private PlayerMover _playerMover;

        private float _ungroundedTimer;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _playerMover = GetComponent<PlayerMover>();
        }

        private void FixedUpdate()
        {
            if (_controller.IsGrounded) _ungroundedTimer = 0f;
            else _ungroundedTimer += Time.deltaTime;

            if (_ungroundedTimer == 0f) _ungroundedTimer = 0.5f;
 
            var fallSpeed = gravity * _ungroundedTimer;
            fallSpeed = fallSpeed < gravityLimit ? gravityLimit : fallSpeed;
            _playerMover.ChangeMove(MoveType.GravityMove, new Vector3(0f, fallSpeed, 0f), RotationType.NoRotation);
        }
    }
}