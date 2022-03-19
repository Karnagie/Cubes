using System.Globalization;
using CubeEssence;
using CubeEssence.Commands;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StatsMenu : MonoBehaviour 
    {
        [SerializeField] private TMP_InputField _speed;
        [SerializeField] private TMP_InputField _delay;
        [SerializeField] private TMP_InputField _distance;

        [Inject] private CubeSpawner[] _spawners;

        private void Awake()
        {
            _speed.text = _spawners[0].Speed.ToString(CultureInfo.InvariantCulture);
            _delay.text = (_spawners[0].Delay/1000).ToString();
            _distance.text = _spawners[0].Direction.magnitude.ToString(CultureInfo.InvariantCulture);
            
            _speed.onValueChanged.AddListener(UpdateSpeed);
            _delay.onValueChanged.AddListener(UpdateDelay);
            _distance.onValueChanged.AddListener(UpdateDistance);
        }

        private void UpdateSpeed(string value)
        {
            if (float.TryParse(value, out var speed))
            {
                foreach (var spawner in _spawners)
                {
                    spawner.ExecuteCommand(new UpdateSpeedCommand(speed));
                }
            }
        }
        
        private void UpdateDelay(string value)
        {
            if (float.TryParse(value, out var delay))
            {
                foreach (var spawner in _spawners)
                {
                    spawner.ExecuteCommand(new UpdateDelayCommand(delay));
                }
            }
        }
        
        private void UpdateDistance(string value)
        {
            if (float.TryParse(value, out var distance))
            {
                foreach (var spawner in _spawners)
                {
                    spawner.ExecuteCommand(new UpdateDistanceCommand(distance));
                }
            }
        }
    }
}