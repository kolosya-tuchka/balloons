using UnityEngine.SceneManagement;

namespace Core.Services.SceneLoader
{
    public class SceneLoader
    {
        public void LoadScene(SceneName sceneName)
        {
            SceneManager.LoadScene(sceneName.ToString());
        }
    }
}