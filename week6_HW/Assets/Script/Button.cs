using System;
using System.Collections;
using System.Collections.Generic;
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
    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            //¹è¿­ Àß¸øÂ«, ±ÍÂú¾Æ¼­ ÀÓÀÇ·Î Ãß°¡
            new Vector3 (0.0f, 0.0f, 0.0f), //»ç¿ëÇÒÀÏ ¾øÀ½
            //À­¸é
            new Vector3 (Mathf.Cos(18), 0.0f, Mathf.Sin(18)),
            new Vector3((0.5f*Mathf.Cos(54)), 0.0f,((0.5f* Mathf.Sin(54)))),
            new Vector3 (Mathf.Cos(90), 0.0f, Mathf.Sin(90)),
            new Vector3((0.5f*Mathf.Cos(126)), 0.0f,((0.5f* Mathf.Sin(126)))),
            new Vector3 (Mathf.Cos(162), 0.0f, Mathf.Sin(162)),
            new Vector3((0.5f*Mathf.Cos(198)), 0.0f,((0.5f* Mathf.Sin(198)))),
            new Vector3 (Mathf.Cos(234), 0.0f, Mathf.Sin(234)),
            new Vector3((0.5f*Mathf.Cos(270)), 0.0f,((0.5f* Mathf.Sin(270)))),
            new Vector3 (Mathf.Cos(306), 0.0f, Mathf.Sin(306)),
            new Vector3((0.5f*Mathf.Cos(342)), 0.0f,((0.5f* Mathf.Sin(342)))),
            //¾Æ·§¸é
            new Vector3 (Mathf.Cos(18), 1.0f, Mathf.Sin(18)),
            new Vector3((0.5f*Mathf.Cos(54)), 1.0f,((0.5f* Mathf.Sin(54)))),
            new Vector3 (Mathf.Cos(90), 1.0f, Mathf.Sin(90)),
            new Vector3((0.5f*Mathf.Cos(126)), 1.0f,((0.5f* Mathf.Sin(126)))),
            new Vector3 (Mathf.Cos(162), 1.0f, Mathf.Sin(162)),
            new Vector3((0.5f*Mathf.Cos(198)), 1.0f,((0.5f* Mathf.Sin(198)))),
            new Vector3 (Mathf.Cos(234), 1.0f, Mathf.Sin(234)),
            new Vector3((0.5f*Mathf.Cos(270)), 1.0f,((0.5f* Mathf.Sin(270)))),
            new Vector3 (Mathf.Cos(306), 1.0f, Mathf.Sin(306)),
            new Vector3((0.5f*Mathf.Cos(342)), 1.0f,((0.5f* Mathf.Sin(342)))),
        };

        mesh.vertices = vertices;

        // Triangle indices for the top and bottom faces
        int[] topTriangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 6,
            0, 6, 7,
            0, 7, 8,
            0, 8, 9,
            0, 9, 10
        };
        int[] bottomTriangles = new int[]
        {
            11, 12, 13,
            11, 13, 14,
            11, 14, 15,
            11, 15, 16,
            11, 16, 17,
            11, 17, 18,
            11, 18, 19,
            11, 19, 20,
            11, 20, 21
        };

        // Combine top and bottom triangle indices
        int[] triangles = new int[topTriangles.Length + bottomTriangles.Length];
        Array.Copy(topTriangles, triangles, topTriangles.Length);
        Array.Copy(bottomTriangles, 0, triangles, topTriangles.Length, bottomTriangles.Length);

        mesh.triangles = triangles;

        mesh.RecalculateNormals(); // Compute normals for smooth shading

        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (mf == null)
            mf = gameObject.AddComponent<MeshFilter>();

        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        if (mr == null)
            mr = gameObject.AddComponent<MeshRenderer>();

        mr.material = new Material(Shader.Find("Custom/ToonShader"));

        mf.mesh = mesh;
    }
}
