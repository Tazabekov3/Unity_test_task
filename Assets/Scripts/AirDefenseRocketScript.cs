using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDefenseRocketScript : MonoBehaviour
{
    [SerializeField] private GameObject smokePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane")) {
            Destroy(gameObject);
        }
    }
}
