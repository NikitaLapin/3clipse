using _3ClipseGame.Steam.GameCore.Origin;
using _3ClipseGame.Steam.GameCore.Origin.Parts.GameStates;
using _3ClipseGame.Steam.GameCore.Origin.Parts.Input.Inputs.HUDInput;
using UnityEngine;

namespace _3ClipseGame.Steam.UserInterface.Menu.Scripts
{
    public class MenuEnabler : MonoBehaviour
    {
        [SerializeField] private HUDInputProcessor _hudInputProcessor;

        private void OnEnable() => _hudInputProcessor.ToggleMenu += EnableMenuGameState;

        private void OnDisable() => _hudInputProcessor.ToggleMenu -= EnableMenuGameState;

        private void EnableMenuGameState() => GameSource.Instance.GetStatesManager().Enable(GameStateType.Menu);
    }
}
