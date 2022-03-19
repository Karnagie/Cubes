using System.Threading.Tasks;
using CubeEssence.CubeFXEssence;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace CubeEssence
{
    public class Cube : MonoBehaviour
    {
        private int _delay;
        private Pusher _pusher;
        private ICubeFX _fx;

        public void Init(Vector3 direction, int delay, float speed, ICubeFX cubeFX)
        {
            _delay = delay;
            _pusher = new Pusher(transform, direction, speed);
            _pusher.OnEnd += Repeat;
            _fx = cubeFX;
            _fx.Init(transform);
        }

        public async void Move()
        {
            await _pusher.Push();
        }

        public async Task Show()
        {
            await _fx.Show();
        }

        private async Task Destroy()
        {
            await _fx.Hide();
        }

        private async Task Repeat()
        {
            await Destroy();
            await Task.Delay(_delay);
            transform.localScale = Vector3.one;
            _pusher.Reset();
            await Show();
            Move();
        }

        public void UpdateSpeed(float speed)
        {
            _pusher.UpdateSpeed(speed);
        }

        public void UpdateDelay(int delay)
        {
            _delay = delay;
        }

        public void UpdateDistance(float distance)
        {
            _pusher.UpdateDistance(distance);
        }
    }
}