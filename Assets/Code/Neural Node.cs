using UnityEngine;

public class NeuralNode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                // Create mesh filter using GetComponent<meshfilter>
        MeshFilter mf = GetComponent<MeshFilter> ();
        Mesh mesh = new Mesh ();
        mf.mesh = mesh;
        // Vertices
        Vector3[] vertices = new Vector3[6] {
        new Vector3(0,0,0),new Vector3(8,0,0),new Vector3(0,10,0),new Vector3(8, 10,0),new Vector3(10,0,1),new Vector3(10,10,1)
        } ;
        // Triangles
        int[] triangles = new int[6];
        triangles [0] = 0;
        triangles [1] = 2;
        triangles [2] = 1;

        triangles [3] = 2;
        triangles [4] = 3;
        triangles [5] = 1;

        triangles [6] = 2;
        triangles [6] = 4;
        triangles [6] = 3;

        triangles [6] = 4;
        triangles [6] = 5;
        triangles [6] = 3;

        // Update mesh with vertices, triangles and normals
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
