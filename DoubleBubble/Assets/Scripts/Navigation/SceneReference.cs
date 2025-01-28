using UnityEditor;
using UnityEngine;

namespace MIDIFrogs.Bubble.Navigation
{
    [CreateAssetMenu(fileName = "SceneReference", menuName = "Tools/Scene Reference")]
    public class SceneReference : ScriptableObject
    {
#if UNITY_EDITOR
        public SceneAsset sceneAsset;
#endif
        public string sceneName;

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (sceneAsset != null)
            {
                sceneName = sceneAsset.name;
            }
#endif
        }
    }
}