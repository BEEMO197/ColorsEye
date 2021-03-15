using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRespawnScript : MonoBehaviour
{
    public Vector3 respawnPoint = new Vector3(0.0f, 5.0f, 0.0f);

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().respawn(respawnPoint);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(respawnPoint, 1.0f);
    }
}
