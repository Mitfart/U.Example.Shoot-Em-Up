using System.Buffers;
using UnityEngine;

namespace Misc
{
    public abstract class Spawner<T> : MonoBehaviour where T : Component
    {
        protected abstract string ContainerTag { get; }

        private Transform _container;
        private ArrayPool<T> _pool;
        
        

        protected virtual void Awake() => CreateContainer();
    
    
        protected T Spawn(T asset, Vector3 pos, Quaternion? rot = null)
        {
            return Instantiate(asset, pos, rot ?? Quaternion.identity, _container);
        }


        private void CreateContainer()
        {   
            _container = new GameObject($"{ContainerTag} - {name}").transform;
        }
    }
}