using System.Collections.Generic;
using UnityEngine;
using CharacterController = _3ClipseGame.Steam.GameCore.GlobalScripts.EntityScripts.CharacterController;

namespace _3ClipseGame.Steam.GameCore.Origin.Parts.Player.Interfaces
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<PlayerEntity> _allPossiblePlayerEntities;
        [SerializeField] private PlayerEntity _currentPlayerEntity;
        
        public PlayerEntity GetCurrentPlayerEntity() => _currentPlayerEntity;

        public void MoveTo(Vector3 position)
        {
            foreach(var entity in _allPossiblePlayerEntities)
                entity.GetComponent<CharacterController>().Teleport(position);
        }

        private void OnEnable() => _currentPlayerEntity.SwitchingToNewEntity += ChangeEntity;
        private void OnDisable() => _currentPlayerEntity.SwitchingToNewEntity += ChangeEntity;

        private void ChangeEntity()
        {
            _currentPlayerEntity.SwitchingToNewEntity -= ChangeEntity;
            _currentPlayerEntity.LoseControl();
            _currentPlayerEntity = FindNextEntity();
            _currentPlayerEntity.TakeControl();
            _currentPlayerEntity.SwitchingToNewEntity += ChangeEntity;
        }

        private PlayerEntity FindNextEntity()
        {
            var currentType = _currentPlayerEntity.GetPlayerEntityType();
            return _allPossiblePlayerEntities.Find(entity => entity.GetPlayerEntityType() != currentType);
        }
    }
}
