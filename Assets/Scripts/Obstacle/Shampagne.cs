using System.Collections;
using System.Collections.Generic;
using Obstacle;
using UnityEngine;

public class Shampagne : InteractionObstacle
{
    public override void Action()
    {
        this.gameObject.SetActive(false);
        base.Action();
    }
}
