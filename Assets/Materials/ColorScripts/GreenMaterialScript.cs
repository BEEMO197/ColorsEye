using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMaterialScript : MonoBehaviour
{
    private bool boostApplied = false;
    private float prevSpeed = 5;
    public float SpeedMultiplier = 1.0f;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Green collision Hit");
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();

        StartCoroutine(increaseSpeed(pc));
    }

    private void OnCollisionExit(Collision collision)
    {
        boostApplied = false;
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        StartCoroutine(pc.resetPlayerSpeed(prevSpeed));
    }
    IEnumerator increaseSpeed(PlayerController pc)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        if (!boostApplied)
        {
            prevSpeed = pc.getPlayerSpeed();
            pc.setPlayerSpeed(pc.getPlayerSpeed() * 2.0f * SpeedMultiplier);
            boostApplied = true;
        }
    }
}
