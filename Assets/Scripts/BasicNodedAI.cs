using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;



public class BasicNodedAI : MonoBehaviour
{

    enum ORDER_OF_ORDER
    {
        NONE,
        SOUND,
        PLAYER
    }

    private ORDER_OF_ORDER currenttarget;

    public float maxDistance = 50.0f;
    
    public string nodeTargets;
    
    private NavMeshAgent _agent;

    private GameObject[] foundObjects;
    private GameObject player;

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
        currenttarget = ORDER_OF_ORDER.NONE;
        player = GameObject.FindWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = GameObject.FindWithTag(nodeTargets).transform.position;
        nodes = new List<GameObject>();
        nodes.Add(GameObject.FindWithTag(nodeTargets));
        getAllNodes();
    }

    

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updating...!");
        RaycastHit[] hits = new RaycastHit[3];
        Vector3 header = player.transform.position - transform.position;
        float dotOwo = Vector3.Dot(header, transform.forward);
        if (dotOwo >= 1 &&
            Vector3.Distance(transform.position, player.transform.position) <= maxDistance)

        {
            int foundHits = Physics.RaycastNonAlloc(transform.position,
                (player.transform.position - transform.position), hits,
                Vector3.Distance(transform.position, player.transform.position));
            if (foundHits < 3)
            {
                bool foundBad = false;
                for (int x = 0; x < foundHits; x++)
                {
                    if (!hits[x].collider.gameObject.CompareTag("Player") &&
                        !hits[x].collider.gameObject.CompareTag(this.tag))
                    {
                        foundBad = true;
                    }
                }

                if (!foundBad)
                {
                    Debug.Log("Good OWO");
                    currenttarget = ORDER_OF_ORDER.PLAYER;
                    _agent.destination = player.transform.position;
                }
            }
        }
        else
        {
            Debug.Log("Not");
        }
        
        switch (currenttarget)
        {
            case ORDER_OF_ORDER.NONE: 
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
                break;
            default:
                if (Vector3.Distance(transform.position, _agent.destination) <= 2)
                {
                    Debug.Log("Found Labron James");
                    currenttarget = ORDER_OF_ORDER.NONE;
                    getAllNodes();
                }
                break;
        }
        
        
    }

    void activateIdle()
    {
        currenttarget = ORDER_OF_ORDER.NONE;
        getAllNodes();
    }

    bool setSoundTarget(GameObject sound)
    {
        if (currenttarget <= ORDER_OF_ORDER.SOUND)
        {
            currenttarget = ORDER_OF_ORDER.SOUND;
        }
        else
        {
            return false;
        }
        _agent.destination = sound.transform.position;
        return true;
    }
    
    
}
