using Enemy;
using UnityEngine;

public class PotatoVigilantBehaviour : EnemyBaseBehaviour
{
    public override void EnterState(EnemyBehaviourManager enemy)
    {
        return;
    }

    public override void Evade(EnemyBehaviourManager enemy)
    {
        return;
    }

    public override void OnCollisionEnter(EnemyBehaviourManager enemy, Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemy.ChangeMood(enemy.FollowBehaviour);
        }
    }

    public override void UpdateState(EnemyBehaviourManager enemy)
    {
        return;
    }
}
