using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyeat : HumanEat
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<SnakeMovment>().fev)
        {
            base.OnTriggerEnter(other);
        }
    }
}
