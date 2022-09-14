using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ElasticTensioner : MonoBehaviour
{
    [SerializeField] private float _maxPointX;
    [SerializeField] private float _minPointX;
    [SerializeField] private float _maxPointZ;
    [SerializeField] private float _minPointZ;

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

        //if(CheckBorders(rayPoint) == true)
            
        transform.position = ClampPosition(rayPoint);
    }

    private bool CheckBorders(Vector3 point)
    {
        if (point.x > _minPointX && point.x < _maxPointX)
            if (point.z > _minPointZ && point.z < _maxPointZ)
                return true;

        return false;
    }

    private Vector3 ClampPosition(Vector3 point)
    {
        float positionX = Mathf.Clamp(point.x, _minPointX, _maxPointX);
        float positionZ = Mathf.Clamp(point.z, _minPointZ, _maxPointZ);

        return new Vector3(positionX, transform.position.y , positionZ);
    }

    private void OnMouseUp()
    {
        _rigidbody.isKinematic = false;
        DragFinished?.Invoke();
    }
}
