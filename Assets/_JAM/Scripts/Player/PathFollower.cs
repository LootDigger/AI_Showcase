using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    private SplineContainer _splineContainer;
    [SerializeField] 
    private float _agentSpeed = 1f;
    [SerializeField] 
    private float _agentHeight = 1.8f;

    private Spline _splinePath;
    private float _splinePosition = 0f;
    private Vector3 _agentPosition;

    void Start()
    {
        if(_splineContainer != null)
        {
            _splinePath = _splineContainer.Spline;
        }

        if(_splinePath == null)
        {
            Debug.LogError(
                "SplineContainer or Spline is not assigned or available. Please assign a valid SplineContainer.");
        }
    }

    void Update()
    {
        if(_splinePath == null)
            return;

        _splinePosition += _agentSpeed * Time.deltaTime;

        if(_splinePosition > 1f)
        {
            _splinePosition -= 1f; // Reset to the start for an infinite loop
        }

        _agentPosition = _splinePath.EvaluatePosition(_splinePosition);
        _agentPosition.y = _agentHeight;
        transform.position = _agentPosition;
    }
}
