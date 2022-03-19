namespace CubeEssence.Commands
{
    public class UpdateSpeedCommand : CubeCommand
    {
        private float _speed;
        
        public UpdateSpeedCommand(float speed)
        {
            _speed = speed;
        }
        
        public override void Execute(Cube cube)
        {
            cube.UpdateSpeed(_speed);
        }
    }
}