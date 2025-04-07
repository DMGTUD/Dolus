using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject managerHolder;
    public const float proximity=0.1f;
    public GameObject currentTarget;
    private WaypointManager waypointManager;
    public const float deceleration_factor = 0.6f;
    Vector3 source;
    Vector3 target;
    Vector3 outputVelocity;
    Vector3 directionToTarget;
    Vector3 velocityToTarget;
    float distanceToTarget;
    float speed;

    [Header("Materials")]
    public Material noTarget;
    public Material yesTarget;

    [Header("Movements")]
    public GameObject initialTarget;
    public int stayThreshold=75;
    private bool isScanning;
    public bool isWaiting;
    public string movementAnimation;
    private bool isFirstTimeMoving=true;

    void Awake()
    {
        waypointManager = managerHolder.GetComponent<WaypointManager>();
        isWaiting=true;
    }

    
    void FixedUpdate()
    {
        if (!isWaiting)
        {
            movementAnimation = "Walking";
            source = transform.position;
            if (isFirstTimeMoving)
            {
                currentTarget = initialTarget;
                currentTarget.GetComponent<MeshRenderer> ().material=yesTarget;
                isFirstTimeMoving=false;
            }
            target = currentTarget.transform.position;
            outputVelocity = Arrive(source,target);
            GetComponent<Rigidbody>().AddForce(outputVelocity, ForceMode.VelocityChange);
            if(Vector3.Distance(source,target)<proximity)
            {
                currentTarget.GetComponent<MeshRenderer> ().material=noTarget;
                int coinToss = Random.Range(1,100);
                //print(coinToss);
                if(coinToss<stayThreshold)
                {
                    DelayMove();
                }
                GameObject tempObject = currentTarget;
                currentTarget = waypointManager.NextWaypoint(tempObject);
                transform.LookAt(currentTarget.transform);
                currentTarget.GetComponent<MeshRenderer> ().material=yesTarget;
            }
        }
        else if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Armature|Walk"))
        {
            isWaiting=false;  
        }


    
        
        
    }

    private Vector3 Arrive (Vector3 source, Vector3 target)
    {
        distanceToTarget = Vector3.Distance(source,target);
        directionToTarget = Vector3.Normalize(target-source);
        speed = 1;
        velocityToTarget = speed * directionToTarget;
        return velocityToTarget - GetComponent <Rigidbody>().linearVelocity;
    }

    public void DelayMove()
    {
        isWaiting=true;
        GetComponent<Animator>().Play("Armature|No Jiggle");
        movementAnimation = "Waiting";


    }
}
