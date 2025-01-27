using UnityEngine;

public class Crumple : MonoBehaviour
{
    public Material stickyNoteTexture;
    public Mesh crupleBall;
    public float crumpleScale;
    public float crumpleSpeed;
    private Vector3[] baseVertices;
    private Vector3[] vertices;
    public bool recalculateNormals;
    public bool changeShape;
    public bool animationEnd;
    private bool animationEndSafety=true;
    private bool uncrumbled = true;
    public float tossForce;

    void Start()
    {
                // Create mesh filter using GetComponent<meshfilter>
        MeshFilter mf = GetComponent<MeshFilter> ();
        Material meshMaterial = GetComponent<MeshRenderer>().material;
        Mesh mesh = new Mesh ();
        mf.mesh = mesh;
        // Vertices
        Vector3[] vertices = new Vector3[6] {new Vector3(0,0,0),new Vector3(10,0,0),new Vector3(0,8,0),new Vector3(10, 8,0),new Vector3(0,10,-0.5f),new Vector3(10,10,-0.5f)};
        
        int[] triangles = new int[12];
        triangles [0] = 0;
        triangles [1] = 2;
        triangles [2] = 1;

        triangles [3] = 2;
        triangles [4] = 3;
        triangles [5] = 1;

        triangles [6] = 2;
        triangles [7] = 4;
        triangles [8] = 3;

        triangles [9] = 4;
        triangles [10] = 5;
        triangles [11] = 3;

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        
        Vector2[] uvs = new Vector2[6];
        uvs[0]=new Vector2(0,0);
        uvs[1]=new Vector2(1024,0);
        uvs[2]=new Vector2(0,844);
        uvs[3]=new Vector2(1024, 844);
        uvs[4]=new Vector2(0,1024);
        uvs[5]=new Vector2(1024,1024);
        mesh.RecalculateNormals();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changeShape)
        {
            if(uncrumbled)
            {
              Crumble();
              uncrumbled=false;  
            }
            changeShape=false;
        }

        if(animationEnd)
        {
            if(animationEndSafety)
            {
               LetGo();
                animationEndSafety=false; 
            }
        }

    }

    public void Crumble()
    {
        transform.localScale = new Vector3(0.003f,0.003f,0.003f);
        GetComponent<MeshFilter>().mesh = crupleBall;
        Destroy(transform.GetChild(0).gameObject);
        CrumbleEffect();
    }

    void CrumbleEffect() 
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        if (baseVertices == null)
        {
            baseVertices = mesh.vertices;
        }

        vertices = new Vector3[baseVertices.Length];
        float timex = Time.time * crumpleSpeed + 2.5564f;
        float timey = Time.time * crumpleSpeed + 1.21688f;
        float timez = Time.time * crumpleSpeed + 0.1365143f;

        for (int i = 0; i < vertices.Length; i++) 
        {
            Vector3 vertex = baseVertices [i];
            vertex.x += Mathf.PerlinNoise (timex + vertex.x, timex + vertex.y) * crumpleScale;
            vertex.y += Mathf.PerlinNoise (timey + vertex.x, timey + vertex.y) * crumpleScale;
            vertex.z += Mathf.PerlinNoise (timez + vertex.x, timez + vertex.y) * crumpleScale;
            vertices [i] = vertex;
        }

        mesh.vertices = vertices;

        if (recalculateNormals) 
        {
            mesh.RecalculateNormals ();
            mesh.RecalculateBounds ();
        }
        
        GetComponent<MeshCollider>().enabled=true;
        GetComponent<MeshCollider>().sharedMesh=mesh; 
    }

    public void AnimateCrumble()
    {
        GetComponent<Animator>().SetBool("Crumple",true);
    }

    public void LetGo()
    {

        
        
        GetComponent<Animator>().enabled=false;
        Vector3 savePosition = transform.position;
        GetComponent<Rigidbody>().useGravity=true;
        print("fsas");
        transform.SetParent(null,true);
        transform.position= new Vector3(-0.29442402720451357f,0.5924279689788818f,-10.390043258666993f);
        GetComponent<Rigidbody>().isKinematic= !GetComponent<Rigidbody>().isKinematic;
        

    }

    private void chChChChanges()
    {
        GetComponent<Rigidbody>().mass= 0.001f;
        GetComponent<Rigidbody>().linearDamping= 0.1f;
        
    }
    
    
    void LateUpdate()
    {
        
    }

    public void Toss()
    {
        if(animationEnd)
        {
           GetComponent<Rigidbody>().AddForce(Vector3.forward*tossForce);
            GetComponent<Rigidbody>().AddForce(Vector3.up*tossForce);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("got Collision");
        if (collision.gameObject.tag=="World")
        {
            print("got sound");
            GetComponent<AudioSource>().Play(0);
        }
        
    }
}



