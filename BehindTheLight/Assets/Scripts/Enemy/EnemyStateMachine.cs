using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState currentState;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private Animator anim;

    private int patrolIndex;
    private float idleTimer;

    public NavMeshAgent Agent { get => agent; }
    public float IdleTimer { get => idleTimer; set => idleTimer = value; }
    public Transform Player { get => player; }
    public Transform[] WayPoints { get => wayPoints; }
    public int PatrolIndex { get => patrolIndex; set => patrolIndex = value; }
    public Animator Anim { get => anim; }

    private void Start()
    {
        currentState?.Enter(this);
    }

    private void Update()
    {
        currentState?.UpdateState(this);
    }

    public void ChangeState(EnemyState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }
}
