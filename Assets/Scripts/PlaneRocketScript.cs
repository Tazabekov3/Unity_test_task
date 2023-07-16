using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRocketScript : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("AirDefenseRocket") || collision.gameObject.CompareTag("Ground")) {
            Destroy(gameObject);
        }
    }
}
