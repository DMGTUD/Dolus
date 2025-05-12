using UnityEngine;
using System;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour
{ 
    int nextIndex;
    public List<GameObject> waypoints= new List<GameObject>();
    public bool interruptor; //if true, selects next target via sequence;
    public GameObject waypointSelected;
    public int chanceDecay=75;
    public int chanceRegen=25;

    public void Start()
    {
        foreach(Transform child in this.transform)
        {
            waypoints.Add(child.gameObject);
        }
    }
    
    
    
    public GameObject NextWaypoint (GameObject current)
    {
        interruptor=current.GetComponent<TargetChance>().sequence;
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
                int roll= UnityEngine.Random.Range(0,99);
                if(roll<waypointSelected.GetComponent<TargetChance>().chance)
                {
                    goodChoice=true;
                }
            }

            RefreshWaypoints();
            waypointSelected.GetComponent<TargetChance>().chance=-chanceDecay;
            return waypointSelected;
            
        }
        

    }

    public GameObject SequenceMethod (GameObject current)
    {
        if(current.GetComponent<TargetChance>().nextTargetA.GetComponent<TargetChance>().chance>=current.GetComponent<TargetChance>().nextTargetB.GetComponent<TargetChance>().chance)
        {
            current.GetComponent<TargetChance>().nextTargetA.GetComponent<TargetChance>().chance=-chanceDecay;
            return current.GetComponent<TargetChance>().nextTargetA;
        }
        else
        {
            current.GetComponent<TargetChance>().nextTargetB.GetComponent<TargetChance>().chance=-chanceDecay;
            return current.GetComponent<TargetChance>().nextTargetB;
        }
        
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
        
        
        int kawesa = UnityEngine.Random.Range(0,sizeCount-1);
        return possibleTargets[kawesa]; 
        //return null;
        
    }

    public void RefreshWaypoints()
    {
        foreach(Transform x in this.transform)
        {
            if(x.GetComponent<TargetChance>().chance<100)
            {
                x.GetComponent<TargetChance>().chance+=chanceRegen;
            }
            
            if(x.GetComponent<TargetChance>().chance>=100)
            {
                 x.GetComponent<TargetChance>().chance=100;
            }
        }
    }


}
