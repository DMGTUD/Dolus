using UnityEngine;

public class WaypointManager : MonoBehaviour
{ 
    int nextIndex;
    public GameObject[] waypoints;
    public bool interruptor;
    public GameObject waypointSelected;

    
    public GameObject NextWaypoint (GameObject current)
    {
        bool goodChoice;
        if(interruptor)
        {
            return SequenceMethod(current);
        }
        else
        {
            goodChoice=false;
            while(!goodChoice)
            {
                waypointSelected=RandomLOSMethod(current);
                int roll= Random.Range(0,99);
                if(roll<waypointSelected.GetComponent<TargetChance>().chance)
                {
                    goodChoice=true;
                }
            }

            RefreshWaypoints();
            waypointSelected.GetComponent<TargetChance>().chance=-25;
            return waypointSelected;
            
        }
        

    }

    public GameObject SequenceMethod (GameObject current)
    {
        if(current!=null)
        {
            for(int i = 0; i<waypoints.Length;i++)
            {
                if(current==waypoints[i])
                {
                    nextIndex = (i+1)%waypoints.Length;
                }
            }
        }
        else
        {
            nextIndex=0;
        }
        return waypoints[nextIndex];
    }

    public GameObject RandomLOSMethod (GameObject current)
    {
        int sizeCount=0;
        foreach(Transform x in this.transform)
        {
            
            Vector3 fromPosition = current.transform.position;
            Vector3 toPosition = x.transform.position;
            Vector3 direction = toPosition - fromPosition;
            RaycastHit hit;

            //print (fromPosition+toPosition+direction);                                                             

            if(Physics.Raycast(fromPosition, direction,out hit,7))
            {
                if(hit.collider.tag == "Waypoint")
                {
                    sizeCount++;
                }
                
            }
            
        }

        //print (sizeCount);
        GameObject[] possibleTargets = new GameObject[sizeCount];
        int count=0;

        foreach(Transform x in this.transform)
        {
            
            Vector3 fromPosition = current.transform.position;
            Vector3 toPosition = x.transform.position;
            Vector3 direction = toPosition - fromPosition;
            RaycastHit hit;

            if(Physics.Raycast(fromPosition, direction,out hit,7))
            {
                if(hit.collider.tag == "Waypoint")
                {
                    possibleTargets[count]=hit.transform.gameObject;
                    count++;
                    //print("got a hit");
                }
            }
            

            
        }
        
        
        int kawesa = Random.Range(0,sizeCount-1);
        return possibleTargets[kawesa]; 
        //return null;
        
    }

    public void RefreshWaypoints()
    {
        foreach(Transform x in this.transform)
        {
            if(x.GetComponent<TargetChance>().chance<100)
            {
                x.GetComponent<TargetChance>().chance+=25;
            }
            
            if(x.GetComponent<TargetChance>().chance>=100)
            {
                 x.GetComponent<TargetChance>().chance=100;
            }
        }
    }


}
