using _3ClipseGame.Steam.GameCore.Origin.Parts.Player.Scripts;

namespace _3ClipseGame.Steam.GameCore.Origin.Parts.Player.MainCharacter.StateMachine.Structure
{
    public abstract class MainCharacterSubState<TFactory, TReturn> : SubState<TFactory, TReturn>
        where TFactory : SubStateFactory
    {
        protected MainCharacterSubState(TFactory factory) : base(factory){}
    }
}