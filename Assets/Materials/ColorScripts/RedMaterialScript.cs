using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMaterialScript : MonoBehaviour
{
    private bool jumpBoostApplied = false;
    private float prevJumpHeight = 1;
    public float JumpMultiplier = 1.0f;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Green collision Hit");
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();

        StartCoroutine(increaseJumpHeight(pc));
    }

    private void OnCollisionExit(Collision collision)
    {
        jumpBoostApplied = false;
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        pc.resetJumpHeight(prevJumpHeight);
    }

    IEnumerator increaseJumpHeight(PlayerController pc)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        if (!jumpBoostApplied)
        {
            prevJumpHeight = pc.getJumpHeight();
            pc.setJumpHeight(prevJumpHeight * 2.0f * JumpMultiplier);
            jumpBoostApplied = true;
        }
    }
}
