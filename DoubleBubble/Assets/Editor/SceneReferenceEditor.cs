using MIDIFrogs.Bubble.Navigation;
using UnityEditor;
using UnityEngine;

namespace MIDIFrogs.Bubble.EditorTools
{
    [CustomEditor(typeof(SceneReference))]
    public class SceneReferenceEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SceneReference sceneReference = (SceneReference)target;

            if (GUILayout.Button("Select scene"))
            {
                string path = EditorUtility.OpenFilePanel("Select scene", "Assets/", "unity");
                if (!string.IsNullOrEmpty(path))
                {
                    path = System.IO.Path.GetFileNameWithoutExtension(path);
                    sceneReference.sceneName = path;
                    EditorUtility.SetDirty(sceneReference);
                }
            }
        }
    }
}