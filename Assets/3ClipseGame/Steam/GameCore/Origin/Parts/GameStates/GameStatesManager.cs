using System.Collections.Generic;
using _3ClipseGame.Steam.GameCore.Origin.Interfaces;
using _3ClipseGame.Steam.GameCore.Origin.Parts.GameStates.States;
using UnityEngine;

namespace _3ClipseGame.Steam.GameCore.Origin.Parts.GameStates
{
    public class GameStatesManager : MonoBehaviour, ISoloManager<GameStateType>
    {
        [SerializeField] private List<GameMode> _gameModes;
        [SerializeField] private GameMode _currentGameMode;

        private void Start()
        {
            if(_currentGameMode != null)
                _currentGameMode.StartEnter();
        }
        
        public void Enable(GameStateType enableObjectType)
        {
            var newMode = _gameModes.Find(mode => mode.GetModeType() == enableObjectType);
            if (newMode != null)
            {
                _currentGameMode.Exit();
                _currentGameMode = newMode;
                _currentGameMode.StartEnter();
            }
        }

        public GameStateType[] GetActive()
        {
            return new GameStateType[]{_currentGameMode.GetModeType()};
        }
    }
}
