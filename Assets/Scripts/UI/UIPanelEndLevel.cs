using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIPanelEndLevel : MonoBehaviour
{
    [SerializeField] private Image _imageResult;
    [SerializeField] private Sprite _spritePlayerWin;
    [SerializeField] private Sprite _spritePlayerDefeat;
    [SerializeField] private TMP_Text _textResult;
    [SerializeField] private TMP_Text _textReward;
    [SerializeField] private Button _buttonWithoutAd;
    [SerializeField] private Button _buttonRetry;
    [SerializeField] private Button _buttonReward;
    [SerializeField] private int _winReward;
    [SerializeField] private int _defeatReward;
    [SerializeField] private SceneSwitcher _sceneSwitcher;


    private const string c_Win = "Win";
    private const string c_Defeat = "Defeat";

    private void OnValidate()
    {
        _sceneSwitcher = FindObjectOfType<SceneSwitcher>();
    }

    private void OnEnable()
    {
        _buttonWithoutAd.onClick.AddListener(OnNextButtonClick);
        _buttonRetry.onClick.AddListener(OnRetryButtonClick);
    }

    private void OnDisable()
    {
        _buttonWithoutAd.onClick.RemoveListener(OnNextButtonClick);
        _buttonRetry.onClick.RemoveListener(OnRetryButtonClick);
    }

    public void OnPlayerWin()
    {
        _imageResult.sprite = _spritePlayerWin;
        _textResult.text = c_Win;
        _textReward.text = _winReward.ToString();
        _buttonReward.gameObject.SetActive(true);
        _buttonRetry.gameObject.SetActive(false);

    }

    public void OnPlayerDefeat()
    {
        _imageResult.sprite = _spritePlayerDefeat;
        _textResult.text = c_Defeat;
        _textReward.text = _defeatReward.ToString();
        _buttonRetry.gameObject.SetActive(true);
        _buttonReward.gameObject.SetActive(false);
    }

    private void OnNextButtonClick()
    {
        _sceneSwitcher.ReloadScene();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void OnRetryButtonClick()
    {
        _sceneSwitcher.ReloadScene();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
