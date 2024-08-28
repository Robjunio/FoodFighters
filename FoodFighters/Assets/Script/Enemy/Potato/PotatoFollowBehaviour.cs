using UnityEngine;

namespace Enemy
{
    public class PotatoFollowBehaviour : EnemyBaseBehaviour
    {
        private Vector2 dir;
        public override void EnterState(EnemyBehaviourManager enemy)
        {
            
        }

        public override void UpdateState(EnemyBehaviourManager enemy)
        {
            Move(enemy);
        }

        public override void OnCollisionEnter(EnemyBehaviourManager enemy, Collision2D col)
        {

        }

        public override void Evade(EnemyBehaviourManager enemy)
        {
       
        }

        private void Move(EnemyBehaviourManager enemy)
        {
            if (enemy.GetTarget() == null) return;
            var dist = Vector2.Distance(enemy.GetTarget().position, enemy.transform.position);

            if (Mathf.Abs(dist) <= enemy.GetMaxDistToPlayer()) 
            {
                dir = Vector2.zero;
                Animate(enemy);
                enemy.ChangeMood(enemy.AttackBehaviour);
            }
            else
            {
                dir = enemy.GetTarget().position - enemy.transform.position;
            }
            var targetVelocity = dir.normalized * enemy.GetSpeed();

            enemy.GetRigidbody2D().velocity = Vector2.Lerp(enemy.GetRigidbody2D().velocity, targetVelocity, 0.8f);
            
            Animate(enemy);
        }

        private void Animate(EnemyBehaviourManager enemy)
        {
            if (dir.x > 0) enemy.transform.localScale = Vector3.one;
            else if (dir.x < 0) enemy.transform.localScale = new Vector3(-1, 1, 1);

            enemy.GetAnimator().SetFloat("Magnitude", dir.magnitude);
        }
    }
}