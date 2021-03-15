using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMaterialScript : MonoBehaviour
{   
    private PlayerController pc;
    private Vector3 posDiff;
    private void Update()
    {
        if(pc != null)
        {
            transform.position = new Vector3(pc.transform.position.x, transform.position.y, pc.transform.position.z) - posDiff;
            posDiff = pc.transform.position - transform.position;
            posDiff.y = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Yellow collision Hit");
        if (collision.collider.CompareTag("Player"))
        {
            pc = collision.gameObject.GetComponent<PlayerController>();

            posDiff = pc.transform.position - transform.position;
            posDiff.y = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            pc = null;
    }
}
