namespace CubeEssence.Commands
{
    public class UpdateDistanceCommand : CubeCommand
    {
        private float _distance;

        public UpdateDistanceCommand(float distance)
        {
            _distance = distance;
        }
        
        public override void Execute(Cube cube)
        {
            cube.UpdateDistance(_distance);
        }
    }
}