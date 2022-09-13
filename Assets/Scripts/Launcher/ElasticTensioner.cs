using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ElasticTensioner : MonoBehaviour
{
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
        transform.position = new Vector3(rayPoint.x, transform.position.y, rayPoint.z);
    }

    private void OnMouseUp()
    {
        _rigidbody.isKinematic = false;
        DragFinished?.Invoke();
    }
}
