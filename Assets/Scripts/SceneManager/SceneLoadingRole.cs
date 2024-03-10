using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneLoadingRole : MonoBehaviour
    {
        public void Out(int scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
