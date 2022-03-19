namespace CubeEssence.Commands
{
    public class UpdateDelayCommand : CubeCommand
    {
        private float _delay;
        
        public UpdateDelayCommand(float delay)
        {
            _delay = delay;
        }
        
        public override void Execute(Cube cube)
        {
            int delay = (int)(_delay * 1000);
            cube.UpdateDelay(delay);
        }
    }
}