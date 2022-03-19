using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CubeEssence.CubeFXEssence
{
    public class DefaultCubeFX : ICubeFX
    {
        private Transform _transform;

        public void Init(Transform transform)
        {
            _transform = transform;
        }

        public async Task Show()
        {
            _transform.localScale = Vector3.zero;
            await _transform.DOScale(1,1).AsyncWaitForCompletion();
        }
        
        public async Task Hide()
        {
            await _transform.DOScale(0,1).AsyncWaitForCompletion();
        }
    }
}