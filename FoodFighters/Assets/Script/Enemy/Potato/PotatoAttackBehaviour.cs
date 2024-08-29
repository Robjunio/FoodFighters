using UnityEngine;

namespace Enemy
{
    public class PotatoAttackBehaviour : EnemyBaseBehaviour
    {
        private bool canRoll = true;
        private float m_RollTime = 0;
        private float m_AttackTime = 0;
        private bool canAttack = true;
        public override void EnterState(EnemyBehaviourManager enemy)
        {
            if (canAttack)
            {
                Attack(enemy);
            }
        }

        public override void UpdateState(EnemyBehaviourManager enemy)
        {
            if (enemy.GetTarget() == null) return;
            if (!canAttack)
            {
                if (m_AttackTime >= enemy.GetAttackCooldown() && !enemy.GetLifeController().isStunned)
                {
                    m_AttackTime = 0;
                    canAttack = true;
                    var dist = Vector2.Distance(enemy.GetTarget().position, enemy.transform.position);
                    if(dist > 0)
                    {
                        enemy.transform.localScale = new Vector3(1, 1, 1);
                    } else
                    {
                        enemy.transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
                else
                {
                    m_AttackTime += Time.deltaTime;
                }
            }

            if (!canRoll)
            {
                if(m_RollTime >=  enemy.GetRollCooldown() && !enemy.GetLifeController().isStunned)
                {
                    m_RollTime = 0;
                    canRoll = true;
                }
                else
                {
                    m_RollTime += Time.deltaTime;
                }
            }
            
            PlayerInArea(enemy);

            var currentVelocity = enemy.GetRigidbody2D().velocity;

            enemy.GetRigidbody2D().velocity = Vector2.Lerp(currentVelocity, Vector2.zero, 0.8f);
        }

        public override void OnCollisionEnter(EnemyBehaviourManager enemy, Collision2D col)
        {

        }

        public override void Evade(EnemyBehaviourManager enemy)
        {
            if (canRoll)
            {
                float value = Random.Range(0f, 1f);
                if (value > enemy.GetEvadingChance())
                {
                    Debug.Log("Should Roll");
                    enemy.GetAnimator().SetTrigger("Roll");
                    enemy.GetRigidbody2D().AddForce(enemy.transform.localScale.x > 0 ? Vector2.right * 60 : Vector2.left * 60, ForceMode2D.Impulse);
                    canRoll = false;
                    m_RollTime = 0;
                }
            }
        }

        private void Attack(EnemyBehaviourManager enemy)
        {
            m_AttackTime = 0;
            enemy.GetAnimator().SetTrigger("Punch1");
            canAttack = false;
        }

        private void PlayerInArea(EnemyBehaviourManager enemy)
        {
            if (enemy.GetTarget() == null) return;
            var dist = Vector2.Distance(enemy.GetTarget().position, enemy.transform.position);

            if (Mathf.Abs(dist) > enemy.GetMaxDistToPlayer() + 4f && !canAttack)
            {
                enemy.ChangeMood(enemy.AttackBehaviour);
            } 
            else if (Mathf.Abs(dist) > enemy.GetMaxDistToPlayer() && canAttack)
            {
                enemy.ChangeMood(enemy.FollowBehaviour);
            }
            else if (canAttack)
            {
                Attack(enemy);
            }
        }
    }
}