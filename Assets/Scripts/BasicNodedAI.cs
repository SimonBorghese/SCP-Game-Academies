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
    
    void getAllNodes()
    {
        foundObjects = GameObject.FindGameObjectsWithTag(nodeTargets);
        nodes = new List<GameObject>();
        foreach (GameObject obj in foundObjects)
        {
            nodes.Add(obj);
        }
        Debug.Log("Setting");
        _agent.destination = nodes[0].transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        getAllNodes();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _agent.destination) <= 2)
        {
            Debug.Log("Removing");
            nodes.RemoveAt(0);
            if (nodes.Count > 0)
            {
                _agent.destination = nodes[0].transform.position;
            }
            else
            {
                getAllNodes();
            }
        }
    }
}
