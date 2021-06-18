using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _maxDistanceBetweenPoints;

    private readonly List<Vector3> _points = new List<Vector3>();

    public static Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };

    public void DrawPath()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            if (DistanceToLastPoint(hit.point) > _maxDistanceBetweenPoints)
            {
                _points.Add(hit.point);
                _lineRenderer.positionCount = _points.Count;
                _lineRenderer.SetPositions(_points.ToArray());
            }
        }
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if (!_points.Any()) return Mathf.Infinity;

        return Vector3.Distance(_points.Last(), point);
    }

    public void CreatePath() => OnNewPathCreated(_points);

    public void ClearPath() => _points.Clear();
}
