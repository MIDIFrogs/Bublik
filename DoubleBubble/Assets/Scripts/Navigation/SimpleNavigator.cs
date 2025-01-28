using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MIDIFrogs.Bubble.Navigation
{
	public class SimpleNavigator : MonoBehaviour
	{
		[SerializeField] private SceneReference sceneToNavigate;

        public void Navigate() => StartCoroutine(BeginLoadScene(sceneToNavigate.sceneName));

        public IEnumerator BeginLoadScene(string name)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                yield break;
            }

            SceneManager.LoadScene(name);
        }
    }
}