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
            //¹è¿­ Àß¸øÂ«, ±ÍÂú¾Æ¼­ ÀÓÀÇ·Î Ãß°¡
            new Vector3 (0.0f, 0.0f, 0.0f), //»ç¿ëÇÒÀÏ ¾øÀ½
            //À­¸é
            new Vector3 (Math.Cos(18), 0.0f, Math.Sin(18)),
            new Vector3((0.5*Math.Cos(54)), 0.0f,((0.5* Math.Sin(54))),
            new Vector3 (Math.Cos(90), 0.0f, Math.Sin(90)),
            new Vector3((0.5*Math.Cos(126)), 0.0f,((0.5* Math.Sin(126))),
            new Vector3 (Math.Cos(162), 0.0f, Math.Sin(162)),
            new Vector3((0.5*Math.Cos(198)), 0.0f,((0.5* Math.Sin(198))),
            new Vector3 (Math.Cos(234), 0.0f, Math.Sin(234)),
            new Vector3((0.5*Math.Cos(270)), 0.0f,((0.5* Math.Sin(270))),
            new Vector3 (Math.Cos(306), 0.0f, Math.Sin(306)),
            new Vector3((0.5*Math.Cos(342)), 0.0f,((0.5* Math.Sin(342))),
            //¾Æ·§¸é
            new Vector3 (Math.Cos(18), 1.0f, Math.Sin(18)),
            new Vector3((0.5*Math.Cos(54)), 1.0f,((0.5* Math.Sin(54))),
            new Vector3 (Math.Cos(90), 1.0f, Math.Sin(90)),
            new Vector3((0.5*Math.Cos(126)), 1.0f,((0.5* Math.Sin(126))),
            new Vector3 (Math.Cos(162), 1.0f, Math.Sin(162)),
            new Vector3((0.5*Math.Cos(198)), 1.0f,((0.5* Math.Sin(198))),
            new Vector3 (Math.Cos(234), 1.0f, Math.Sin(234)),
            new Vector3((0.5*Math.Cos(270)), 1.0f,((0.5* Math.Sin(270))),
            new Vector3 (Math.Cos(306), 1.0f, Math.Sin(306)),
            new Vector3((0.5*Math.Cos(342)), 1.0f,((0.5* Math.Sin(342))),
        };

        mesh.vertices = vertices;
        //¶Ñ²±
        int[] starBuildingVerteciesUp = new int[]
        {
            1,2,10,
            2,3,4,
            4,5,6,
            6,7,8,
            8,9,10,
            2,10,8,
            2,4,8,
            4,6,8,
        };
        //¹Ù´Ú
        int[] starBuildingVerteciesDown = new int[]
        {
            11,12,20,
            12,13,14,
            14,15,16,
            16,17,18,
            18,19,20,
            12,20,18,
            12,14,18,
            14,16,18,
        };
        //¿·¸éµé
        int[] starBuildingVertecisSide1 = new int[]
        {
            1,2,11,
            2,11,12,
        };
        int[] starBuildingVertecisSide2 = new int[]
        {
            2,3,12,
            3,12,13,
        };
        int[] starBuildingVertecisSide3 = new int[]
        {
            3,4,13,
            4,13,14,
        };
        int[] starBuildingVertecisSide4 = new int[]
        {
            4,5,14,
            5,14,15,
        };
        int[] starBuildingVertecisSide5 = new int[]
        {
            5,6,15,
            6,15,16,
        };
        int[] starBuildingVertecisSide6 = new int[]
        {
            6,7,16,
            7,16,17,
        };
        int[] starBuildingVertecisSide7 = new int[]
        {
            7,8,17,
            8,17,18,
        };
        int[] starBuildingVertecisSide8 = new int[]
        {
            8,9,18,
            9,18,19,
        };
        int[] starBuildingVertecisSide9 = new int[]
        {
            9,10,19,
            10,19,20,
        };
        int[] starBuildingVertecisSide10 = new int[]
        {
            10,1,20,
            1,20,11,
        };
        int[] starBuildingIndices = new int[12];
        starBuildingIndices[0] = starBuildingVerteciesUp;
        starBuildingIndices[1] = starBuildingVerteciesDown;
        starBuildingIndices[2] = starBuildingVertecisSide1;
        starBuildingIndices[3] = starBuildingVertecisSide2;
        starBuildingIndices[4] = starBuildingVertecisSide3;
        starBuildingIndices[5] = starBuildingVertecisSide4;
        starBuildingIndices[6] = starBuildingVertecisSide5;
        starBuildingIndices[7] = starBuildingVertecisSide6;
        starBuildingIndices[8] = starBuildingVertecisSide7;
        starBuildingIndices[9] = starBuildingVertecisSide8;
        starBuildingIndices[10] = starBuildingVertecisSide9;
        starBuildingIndices[11] = starBuildingVertecisSide10;

        mesh.starBuilding = starBuildingIndices;

        //week6 °úÁ¦
        mesh.RecalculateNormals();

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();
        mr.material.color = Color.yellow;

        mf.mesh = mesh;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
