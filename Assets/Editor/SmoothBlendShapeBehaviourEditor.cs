using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SmoothBlendShapeBehaviour))]
    public class SmoothBlendShapeBehaviourEditor : UnityEditor.Editor
    {
        private int _index;

        private float _value;

        private string _name;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(15);
            GUILayout.Label("Tools", EditorStyles.boldLabel);

            GUILayout.Label("Set Blend Shape by Index", EditorStyles.wordWrappedMiniLabel);
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label("Index");
                GUILayout.Space(5);
                _index = EditorGUILayout.IntField(_index);
                GUILayout.Space(15);
                GUILayout.Label("Value");
                GUILayout.Space(5);
                _value = EditorGUILayout.FloatField(_value);
                if (GUILayout.Button("Set"))
                {
                    ((SmoothBlendShapeBehaviour) target).SetBlendShapeWeight(_index, _value);
                }
            }

            GUILayout.Space(5);
            
            GUILayout.Label("Set Blend Shape by Name", EditorStyles.wordWrappedMiniLabel);
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label("Name");
                GUILayout.Space(5);
                _name = EditorGUILayout.TextField(_name);
                GUILayout.Space(15);
                GUILayout.Label("Value");
                GUILayout.Space(5);
                _value = EditorGUILayout.FloatField(_value);
                if (GUILayout.Button("Set"))
                {
                    ((SmoothBlendShapeBehaviour) target).SetBlendShapeWeight(_name, _value);
                }
            }
        }
    }
}