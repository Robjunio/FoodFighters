using UnityEngine;

namespace Enemy
{
    public abstract class EnemyBehaviourManager : MonoBehaviour
    {
        [Header("Enemy Attributes")]
        [SerializeField] private float speed;
        [SerializeField] private float maxDistToPlayer;
        [SerializeField] private float attackingSpeed;
        [SerializeField] private float cooldownBetweenAttacks;
        [SerializeField] private float cooldownBetweenRolls;
        [SerializeField] private float evadingChance;
        [SerializeField] private float damage;

        [Header("Enemy Components")]
        [SerializeField] private Animator anim;
        [SerializeField] private LifeController _health;
        [SerializeField] private Rigidbody2D rb2D;
        private Transform target;

        public EnemyBaseBehaviour AttackBehaviour { get; protected set; }
        public EnemyBaseBehaviour FollowBehaviour { get; protected set; }

        private EnemyBaseBehaviour _currentBehaviour;

        protected virtual void Awake()
        {
            
        }

        protected virtual void Start()
        {
            var targets = GameObject.FindGameObjectsWithTag("Player");
            if (targets.Length > 1)
            {
                target = targets[Random.Range(0, targets.Length)].transform;
            }
            else
            {
                target = targets[0].transform;
            }

            _currentBehaviour = FollowBehaviour;
        }

        private void Update()
        {
            _currentBehaviour.UpdateState(this);
        }

        private void Evade()
        {
            _currentBehaviour.Evade(this);
        }

        public virtual void ChangeMood(EnemyBaseBehaviour behaviour)
        {
            behaviour.EnterState(this);
            _currentBehaviour = behaviour;
        }

        public Animator GetAnimator()
        {
            return anim;
        }

        public Rigidbody2D GetRigidbody2D()
        {
            return rb2D;
        }

        public LifeController GetLifeController()
        {
            return _health;
        }

        public Transform GetTarget()
        {
            return target;
        }

        public float GetMaxDistToPlayer()
        {
            return maxDistToPlayer;
        }
        
        public float GetSpeed()
        {
            return speed;
        }
        
        public float GetAttackingSpeed()
        {
            return attackingSpeed;
        }
        
        public float GetAttackCooldown()
        {
            return cooldownBetweenAttacks;
        }

        public float GetRollCooldown()
        {
            return cooldownBetweenRolls;
        }

        public float GetEvadingChance()
        {
            return evadingChance;
        }

        public float GetDamage()
        {
            return damage;
        }

        void OnEnable()
        {
            PlayerController.Attack += Evade;
        }
        void OnDisable()
        {
            PlayerController.Attack -= Evade;
        }
    }
}
