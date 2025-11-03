using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(WaterFloat))]

public class WF_Inspector : Editor
{
    SerializedProperty amplitude,
    frequency,
    rotationAmplitude,
    rotationFrequency;

    void OnEnable()
    {
        amplitude = serializedObject.FindProperty("amplitude");
        frequency = serializedObject.FindProperty("frequency");    
        rotationAmplitude = serializedObject.FindProperty("rotationAmplitude");
        rotationFrequency = serializedObject.FindProperty("rotationFrequency");
    }

    public override void OnInspectorGUI()
    {
        var button = GUILayout.Button("Click for more tools");
        if (button) Application.OpenURL("https://bit.ly/3CyjBzT");

        WaterFloat script = (WaterFloat)target;
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Floating height and speed", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(amplitude);
        EditorGUILayout.PropertyField(frequency);
        
        EditorGUILayout.Space(10);

        EditorGUILayout.LabelField("Rotation angle and speed", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(rotationAmplitude);
        EditorGUILayout.PropertyField(rotationFrequency);

        serializedObject.ApplyModifiedProperties();
    }
}