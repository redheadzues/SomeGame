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
    [SerializeField] private Button _buttonNext;
    [SerializeField] private Button _buttonRetry;
    [SerializeField] private int _winReward;
    [SerializeField] private int _defeatReward;


    private const string c_Win = "Win";
    private const string c_Defeat = "Defeat";

    public void OnPlayerWin()
    {
        _imageResult.sprite = _spritePlayerWin;
        _textResult.text = c_Win;
        _textReward.text = _winReward.ToString();
        _buttonNext.gameObject.SetActive(true);
        _buttonRetry.gameObject.SetActive(false);

    }

    public void OnPlayerDefeat()
    {
        _imageResult.sprite = _spritePlayerDefeat;
        _textResult.text = c_Defeat;
        _textReward.text = _defeatReward.ToString();
        _buttonRetry.gameObject.SetActive(true);
        _buttonNext.gameObject.SetActive(false);
    }
}
