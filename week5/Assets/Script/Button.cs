using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaticMeshGen))]
public class StaticMeshGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        StaticMeshGen script = (StaticMeshGen)target;
        if (GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }
    }
}

public class StaticMeshGen : MonoBehaviour
{
    // Start is called before the first frame update
    void GenerateMesh()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
