using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    private Vector3 endPosition = new Vector3(0, 50, 0);
    public float speed = 2f;
    public float rocketSpeed = 200f;
    public float scatteringForce = 30f;

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private GameObject rocketSpawnPoint;
    [SerializeField] private GameObject shattersPrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject firePrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(100, 50, 0);
        Invoke("Shoot", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    }

    void Shoot()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint.transform.position, Quaternion.identity);
       
        Rigidbody rb = rocket.GetComponent<Rigidbody>();
        rb.velocity = direction * rocketSpeed;
        rocket.transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AirDefenseRocket")) {
            GameObject shatters = Instantiate(shattersPrefab, transform.position, transform.rotation);

            var rbs = shatters.GetComponentsInChildren<Rigidbody>();

            foreach (var obj in rbs) {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.AddExplosionForce(300, collision.contacts[0].point, 5);
                // GameObject fire = Instantiate(firePrefab, obj.transform.position, Quaternion.identity);
                // fire.transform.SetParent(obj.transform);
                // fire.transform.localScale = Vector3.one;
                // fire.transform.localRotation = Quaternion.identity;
            }

            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 3f);
        }
    }
}
