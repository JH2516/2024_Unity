using System;
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
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3 (Math.Cos(90), 0.0f, Math.Sin(90)),//1,4
            new Vector3 (Math.Cos(162), 0.0f, Math.Sin(162)),//2,1,6
            new Vector3 (Math.Cos(234), 0.0f, Math.Sin(234)),//3,3
            new Vector3 (Math.Cos(306), 0.0f, Math.Sin(306)),//4,5
            new Vector3 (Math.Cos(18), 0.0f, Math.Sin(18)),//5,2
        };

        mesh.vertices = vertices;

        int[] starBuilding = new int[]
        {
            1,4,2,0,3,1,
        };

        mesh.starBuilding = starBuildingIndices;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
