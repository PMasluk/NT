using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectSpawner))]
public class ObjectSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObjectSpawner myScript = (ObjectSpawner)target;
        if (GUILayout.Button("Create Object Pool"))
        {
            myScript.CreateObjects();
        }
        if (GUILayout.Button("Remove All Objects"))
        {
            myScript.RemoveAllObjects();
        }
    }
}
