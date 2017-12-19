using UnityEngine;
using UnityEngine.SceneManagement;

class SceneLoader: MonoBehaviour {

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
