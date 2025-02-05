using UnityEngine;

namespace Core.Services.ResourceProvider
{
    public class ResourceProvider : IResourceProvider
    {
        public GameObject LoadAndInstantiate(string address)
        {
            var prefab = Resources.Load<GameObject>(address);
            return Object.Instantiate(prefab);
        }

        public GameObject LoadAndInstantiate(string address, Transform parent)
        {
            var prefab = Resources.Load<GameObject>(address);
            return Object.Instantiate(prefab, parent);
        }
    }
}