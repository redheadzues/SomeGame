using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ElasticTensioner : MonoBehaviour
{
    [SerializeField] private float _minPointX;
    [SerializeField] private float _maxPointX;
    [SerializeField] private float _minPointZ;
    [SerializeField] private float _maxPointZ;


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
