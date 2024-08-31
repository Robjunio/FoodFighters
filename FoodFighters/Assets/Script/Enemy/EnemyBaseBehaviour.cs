using UnityEngine;

namespace Enemy
{
    public abstract class EnemyBaseBehaviour
    {
        public abstract void EnterState(EnemyBehaviourManager enemy);

        public abstract void UpdateState(EnemyBehaviourManager enemy);

        public abstract void OnCollisionEnter(EnemyBehaviourManager enemy, Collider2D col);

        public abstract void Evade(EnemyBehaviourManager enemy);
        
    }
}
