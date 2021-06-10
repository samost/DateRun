using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Obstacle
{
    public class Dirt : InteractionObstacle
    {
        [SerializeField] private Image dirtUI;

        public override void Action()
        {
            base.Action();
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(dirtUI.DOFade(1f, 0.5f)).Append(dirtUI.DOFade(0f, 0.5f).SetDelay(0.5f));
        }
        
        
    }
}