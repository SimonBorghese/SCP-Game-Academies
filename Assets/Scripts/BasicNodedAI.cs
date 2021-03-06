using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


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
        _agent.destination = new Vector3(nodes[0].transform.position.x, 
            transform.position.y,
            nodes[0].transform.position.z);
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
                    currenttarget = ORDER_OF_ORDER.PLAYER;
                    _agent.destination = player.transform.position;
                }
            }
        }
        else
        {
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
                        _agent.destination = new Vector3(nodes[0].transform.position.x, 
                                transform.position.y,
                                nodes[0].transform.position.z);
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

    public bool setSoundTarget(GameObject sound)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
