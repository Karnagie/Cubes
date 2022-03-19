using System.Threading.Tasks;
using UnityEngine;

namespace CubeEssence.CubeFXEssence
{
    public interface ICubeFX
    {
        void Init(Transform transform);
        Task Show();
        Task Hide();
    }
}