using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BulletPool))]
public class BulletPoolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BulletPool myScript = (BulletPool)target;
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
