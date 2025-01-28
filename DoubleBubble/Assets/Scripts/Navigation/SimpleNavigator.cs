using UnityEngine;

namespace MIDIFrogs.Bubble.Navigation
{
	public class SimpleNavigator : MonoBehaviour
	{
		[SerializeField] private SceneReference sceneToNavigate;

        private SceneLoader sceneLoader;

        private void Start()
        {
            sceneLoader = GameServices.Instance.SceneLoader;
        }

        public void Navigate() => sceneLoader.Load(sceneToNavigate.sceneName);
    }
}