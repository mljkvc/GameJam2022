using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Basic Stats
    protected int attackPower = 20;
    protected int healthBar = 100;
    protected float pushForce = 2.0f;

    // Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage()
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            healthBar -= attackPower;
            pushDirection = pushForce * pushDirection;
        }
    }

    protected virtual void Death()
    {

    }
}
