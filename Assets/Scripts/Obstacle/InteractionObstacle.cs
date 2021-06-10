using UnityEngine;

namespace Obstacle
{
    public abstract class InteractionObstacle: MonoBehaviour
    {
        [SerializeField] protected bool isBuff;

        public virtual void Action()
        {
            if (isBuff)
            {
                BarController.Instance.Buff();  
            }
            else
            {
                BarController.Instance.DeBuff();
            }
        }
    }
}