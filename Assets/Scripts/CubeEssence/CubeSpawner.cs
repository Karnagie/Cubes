using System.Collections.Generic;
using CubeEssence.Commands;
using CubeEssence.CubeFXEssence;
using UnityEngine;
using Zenject;

namespace CubeEssence
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private CubeStats _stats;

        private Cube _cube;

        [Inject] private ICubeFX _cubeFX;

        public Vector3 Direction => _stats.Direction;
        public int Delay => _stats.Delay;
        public float Speed => _stats.Speed;

        private void Awake()
        {
            InitCube();
        }

        private async void InitCube()
        {
            var cube = Instantiate(_stats.Prefab);
            cube.transform.position = transform.position;
            cube.Init(transform.position+Direction, Delay, Speed, _cubeFX);
            await cube.Show();
            cube.Move();
            _cube = cube;
        }

        private void OnDrawGizmos()
        {
            if(!_stats) return;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position+Direction);
        }
        
        public void ExecuteCommand(CubeCommand spawnerCommand)
        {
            spawnerCommand.Execute(_cube);
        }
    }
}