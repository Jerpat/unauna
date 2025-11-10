using UnityEngine;
using UnityEngine.AI;

public class MoveableStuff : Stuff, IInteractable, IMoveable
{
    public bool isInteractable { get => CanUse; set => CanUse = value; }
    public bool isMoving { get => _isMoving; set => _isMoving = value; }

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stopDistance = 1.5f;
    [SerializeField] private Vector3 followOffset = new Vector3(0, 0.5f, 0);

    private bool _isMoving = false;
    private Transform _target;
    private Animator _animator;
    private NavMeshAgent _agent;

    public void Interact(Player player)
    {
        if (!_isMoving)
        {
            StartMove(player.transform);
            Debug.Log("Start following");
        }
        else
        {
            StopMove();
            Debug.Log("Stop following");
        }
    }

    public void StartMove(Transform target)
    {
        _target = target;
        _isMoving = true;

        if (_animator != null)
        {
            _animator.SetBool("Walk", true);
        }
    }

    public void StopMove()
    {
        _target = null;
        _isMoving = false;

        if (_agent != null) // nav mesh
        {
            _agent.ResetPath();
        }

        if (_animator != null)
        {
            _animator.SetBool("Walk", false);
        }
    }

    public void Move(Vector3 direction)
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        if (_agent != null)
        {
            _agent.speed = moveSpeed;
            _agent.stoppingDistance = stopDistance;
            // _agent.updateRotation = false;
        }
    }

    private void Update()
    {
        if (!_isMoving || _target == null || _agent == null) return;

        _agent.SetDestination(_target.position + followOffset);

        Vector3 direction = (_target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, _target.position);

        if (_agent.remainingDistance > _agent.stoppingDistance)
        {
            Move(direction);
            if (_animator != null)
                _animator.SetBool("Walk", true);
        }
        else
        {
            if (_animator != null)
                _animator.SetBool("Walk", false);
        }
    }
}
