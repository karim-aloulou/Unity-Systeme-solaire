using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class systemeSolaire : MonoBehaviour
{
    public float gravité;
    public float vélocitéx;
    public Rigidbody rb;
    public Transform soleil;
    public Transform terre;
    public Transform lune;
    public float distanceTerreLune;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity += transform.right * vélocitéx * Time.deltaTime;
    }

void Update()
{
    Vector3 directionSoleilTerre = (soleil.position - terre.position).normalized;
    rb.velocity += directionSoleilTerre * gravité * Time.deltaTime / Vector3.Distance(soleil.position, terre.position);

    Vector3 directionTerreLune = (terre.position - lune.position).normalized;
    Vector3 positionLune = terre.position + directionTerreLune * distanceTerreLune;
    lune.position = positionLune;

    lune.RotateAround(terre.position, Vector3.up, 15f * Time.deltaTime);
}

}
