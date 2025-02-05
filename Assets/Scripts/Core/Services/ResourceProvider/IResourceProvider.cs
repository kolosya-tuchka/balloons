using UnityEngine;

namespace Core.Services.ResourceProvider
{
    public interface IResourceProvider
    {
        GameObject LoadAndInstantiate(string address);
        GameObject LoadAndInstantiate(string address, Transform parent);
    }
}