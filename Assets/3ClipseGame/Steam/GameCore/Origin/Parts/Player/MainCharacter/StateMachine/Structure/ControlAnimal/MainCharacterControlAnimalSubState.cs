namespace _3ClipseGame.Steam.GameCore.Origin.Parts.Player.MainCharacter.StateMachine.Structure.ControlAnimal
{
    public abstract class MainCharacterControlAnimalSubState : MainCharacterSubState<ControlAnimalSubStateFactory, MainCharacterControlAnimalSubState>
    {
        protected MainCharacterControlAnimalSubState(ControlAnimalDto controlAnimalDto, ControlAnimalSubStateFactory factory) : base(factory)
        {
            ControlAnimalDto = controlAnimalDto;
        }

        protected readonly ControlAnimalDto ControlAnimalDto;
    }
}