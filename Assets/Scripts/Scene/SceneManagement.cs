using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneManagement  : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
