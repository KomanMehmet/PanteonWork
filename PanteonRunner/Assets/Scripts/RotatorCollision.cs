using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorCollision : MonoBehaviour
{
    float force = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * force, ForceMode.Impulse);
        }
    }
}
