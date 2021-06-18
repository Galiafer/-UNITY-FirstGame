using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _agentSpeed  = 10f;
    [SerializeField] private float _remainingDistance  = .5f;

    private Queue<Vector3> _pathPoints = new Queue<Vector3>();

    private void Start() => PathDrawer.OnNewPathCreated += SetPoints;

    private void SetPoints(IEnumerable<Vector3> points) => _pathPoints = new Queue<Vector3>(points);

    private bool ShouldSetDestination()
    {
        if (_pathPoints.Count == 0) return false;
        if (_agent.hasPath == false || _agent.remainingDistance < _remainingDistance) return true;

        return false;
    }

    public void StartFollow()
    {
        _agent.speed = _agentSpeed;

        if (ShouldSetDestination()) _agent.SetDestination(_pathPoints.Dequeue());
    }

    //public void CancelFollow() => _agent.isStopped = true;
}
