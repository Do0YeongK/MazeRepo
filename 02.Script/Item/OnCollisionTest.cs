using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("OnCollision");
        }
    }
}
