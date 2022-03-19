using UnityEngine;

namespace CubeEssence
{
    [CreateAssetMenu(fileName = "CubeStats", menuName = "Cube statistics", order = 0)]
    public class CubeStats : ScriptableObject
    {
        [SerializeField] private Cube _prefab;
        [SerializeField] private Vector3 _direction;
        [SerializeField] private int _delay;
        [SerializeField] private float _speed;

        public Cube Prefab => _prefab;

        public Vector3 Direction => _direction;

        public int Delay => _delay;

        public float Speed => _speed;
    }
}