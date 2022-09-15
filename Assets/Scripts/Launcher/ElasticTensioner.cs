using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ElasticTensioner : MonoBehaviour
{
    private float _minPointX = -4;
    private float _maxPointX = 3;
    private float _minPointZ = -27;
    private float _maxPointZ = -20;


    private Rigidbody _rigidbody;

    public event UnityAction DragStarted;
    public event UnityAction DragFinished;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        _rigidbody.isKinematic = true;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        DragStarted?.Invoke();
    }

    private void OnMouseDrag()
    {
        var distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        transform.position = ClampPosition(rayPoint);
    }

    private Vector3 ClampPosition(Vector3 point)
    {
        float pointX = Mathf.Clamp(point.x, _minPointX, _maxPointX);
        float pointZ = Mathf.Clamp(point.z, _minPointZ, _maxPointZ);

        return new Vector3(pointX, transform.position.y, pointZ);
    }

    private void OnMouseUp()
    {
        _rigidbody.isKinematic = false;
        DragFinished?.Invoke();
    }
}
