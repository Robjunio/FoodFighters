namespace Enemy
{
    public class PotatoBehaviourManager : EnemyBehaviourManager
    {
        protected override void Awake()
        {
            VigilantBehaviour = new PotatoVigilantBehaviour();
            AttackBehaviour = new PotatoAttackBehaviour();
            FollowBehaviour = new PotatoFollowBehaviour();
        }
    }
}