using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMaterialScript : MonoBehaviour
{
    public float BouncePower = 0.9f;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        Vector3 bounceVel = new Vector3(pc.getPreviousPlayerVelocity().x, pc.getBounceVelocityY() * -(BouncePower * pc.getJumpHeight()), pc.getPreviousPlayerVelocity().z);
        Debug.Log("Blue collision Hit With a Velocity of: " + bounceVel);

        if(pc.getBounceVelocityY() <= -2.0f)
            pc.setVelocity(bounceVel);
    }

}
