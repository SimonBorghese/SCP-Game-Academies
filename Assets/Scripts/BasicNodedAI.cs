using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class BasicNodedAI : MonoBehaviour
{
    public string nodeTargets;
    
    private NavMeshAgent _agent;

    private GameObject[] foundObjects;

    private List<GameObject> nodes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void getAllNodes()
    {
        foundObjects = GameObject.FindGameObjectsWithTag(nodeTargets);
        nodes = new List<GameObject>();
        foreach (GameObject obj in foundObjects)
        {
            nodes.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
