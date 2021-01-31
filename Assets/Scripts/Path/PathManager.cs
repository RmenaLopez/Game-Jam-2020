using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathManager : MonoBehaviour
{
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform end;
    [SerializeField]
    private Transform pathLight;
    // Start is called before the first frame update

    private Rigidbody2D endRb;
    private Rigidbody2D startRb;

    private int currentWaypoint = 0;
    private bool reachEndOfPath = false;

    Seeker seeker;
    Path path;

    private bool canCreatePath = false;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        endRb = end.GetComponent<Rigidbody2D>();
        startRb = start.GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 2.5f);
        
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canCreatePath)
        {
            if (path == null)
                return;
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachEndOfPath = true;
                return;
            }
            else
            {
                reachEndOfPath = false;
            }

            if (!reachEndOfPath)
            {
                GameObject.Instantiate(pathLight, path.vectorPath[currentWaypoint], Quaternion.identity);
                currentWaypoint += 3;
            }
        }
    }

    void UpdatePath()
    {
        if (startRb == null)
        {
            return;
        }
        if (seeker.IsDone() && canCreatePath)
            seeker.StartPath(startRb.position, endRb.position, OnPathComplete);
    }

    public void SetEnd(Rigidbody2D end)
    {
        this.endRb = end;
    }

    public void EnableSeeker()
    {
        canCreatePath = true;
    }

    public void DisableSeeker()
    {
        canCreatePath = false;
    }
}
