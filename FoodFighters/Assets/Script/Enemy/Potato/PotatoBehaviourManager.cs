namespace Enemy
{
    public class PotatoBehaviourManager : EnemyBehaviourManager
    {
        protected override void Awake()
        {
            AttackBehaviour = new PotatoAttackBehaviour();
            FollowBehaviour = new PotatoFollowBehaviour();
        }
    }
}