using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectsPool
{
    [SerializeField] private StickmanAnimator _template;
    [SerializeField] private float _spawntime;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PathKeeper _pathKeeper;

    private void Start()
    {
        InitializePool(_template);
        StartCoroutine(OnSpawn());
    }

    private void Spawn()
    {
        if(TryGetObject(out StickmanAnimator stickman))
        {
            stickman.transform.position = _spawnPoint.position;
            
            if(stickman.gameObject.TryGetComponent<StickmanPathFollower>(out StickmanPathFollower follower))
                follower.InitializePathKeeper(_pathKeeper);

            stickman.gameObject.SetActive(true);
        }
    }

    private IEnumerator OnSpawn()
    {
        var waitingTime = new WaitForSeconds(_spawntime);

        while(true)
        {
            Spawn();

            yield return waitingTime;
        }
    }

}
