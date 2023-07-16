using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDefenseScript : MonoBehaviour
{
    public float sightRadius = 60f;
    public float rocketSpeed = 200f;
    private bool hasShot = false;

    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private GameObject rocketSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, sightRadius, targetLayer);

        if (targets.Length != 0 && !hasShot) {
            Shoot(targets[0].gameObject);
            hasShot = true;
        }
    }

    void Shoot(GameObject target)
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint.transform.position, Quaternion.identity);

        Rigidbody rb = rocket.GetComponent<Rigidbody>();
        rb.velocity = direction * rocketSpeed;
        rocket.transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
