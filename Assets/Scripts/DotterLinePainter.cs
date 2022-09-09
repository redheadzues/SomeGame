using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DotterLinePainter : DirectionFinder
{
    [SerializeField] private float _length;
    [SerializeField] private ElasticTensioner _elasticTensioner;


    private LineRenderer _line;

    private void OnEnable()
    {
        _elasticTensioner.DragStarted += OnDragStarted;
        _elasticTensioner.DragFinished += OnDragFinished;
    }

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void OnDisable()
    {
        _elasticTensioner.DragStarted += OnDragStarted;
        _elasticTensioner.DragFinished += OnDragFinished;
    }

    private void OnDragStarted()
    {
        _line.enabled = true;
    }

    private void OnDragFinished()
    {
        _line.enabled = false;
    }

    private void Update()
    {
        if(_line.enabled == true)
        {
            _line.SetPosition(0, _launcher.position);
            _line.SetPosition(1, _launcher.position + GetNormalizedVector() * _length);
        }
    }
}
