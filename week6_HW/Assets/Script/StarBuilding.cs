using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //디자이너가 만든 오브젝트
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0.0f,0.0f,0.0f),
            new Vector3(1.0f,0.0f,0.0f),
            new Vector3(1.0f,1.0f,0.0f),
        };
        mesh.vertices = vertices;
        //오른손
        int[] triangleIndeces = new int[]
        {
            0,2,1,
        };
        mesh.triangles = triangleIndeces;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
