using UnityEngine;

public class LevelEvent : MonoBehaviour
{
    [SerializeField] private AlliedCastleBreacker _alliedCastle;
    [SerializeField] private EnemyCastleBreaker _enemyCastle;
    [SerializeField] private UIPanelEndLevel _endLevelPanel;


    private void OnValidate()
    {
        _alliedCastle = FindObjectOfType<AlliedCastleBreacker>();
        _enemyCastle = FindObjectOfType<EnemyCastleBreaker>();
        _endLevelPanel = FindObjectOfType<UIPanelEndLevel>();

    }

    private void OnEnable()
    {
        _alliedCastle.CastleBreacked += OnAlliedCastleBreacked;
        _enemyCastle.CastleBreacked += OnEnemyCastleBreacked;
        _endLevelPanel.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _alliedCastle.CastleBreacked -= OnAlliedCastleBreacked;
        _enemyCastle.CastleBreacked -= OnEnemyCastleBreacked;
    }

    private void OnEnemyCastleBreacked()
    {
        ActivatePanel();
        _endLevelPanel.OnPlayerWin();
        Time.timeScale = 0;
    }

    private void OnAlliedCastleBreacked()
    {
        ActivatePanel();
        _endLevelPanel.OnPlayerDefeat();
        Time.timeScale = 0;
    }

    private void ActivatePanel()
    {
        _endLevelPanel.gameObject.SetActive(true);
    }
}
