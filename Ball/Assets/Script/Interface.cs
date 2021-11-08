using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField]private Text _scoreText;
    [SerializeField]private Text _healthText;
    [SerializeField]private Text _pouseButtonText;
    [SerializeField]private Text _bestText;
    [SerializeField]private Button _restartButton;
    private int _displayScore;
    private void Start()
    {
        _displayScore = 0;
    }
    public void ShowPlay() 
    {
        _pouseButtonText.text = "||";
    }
    public void ShowPouse()
    {
        _pouseButtonText.text = "►";
    }
    public void ShowScore(int score)
    {
        if (_scoreText != null)
        {
            _displayScore += score;
            _scoreText.text = $"Score:{_displayScore}";
        }
    }
    public void ShowHealth(int health)
    {
        if (_healthText != null)
        {
            _healthText.text = $"Health: {health}";
        }
    }
    public void ShowDeafe()
    {
        _bestText.text = $"Best: {Menu.BestScore}";
        _bestText.gameObject.SetActive(true);
        _restartButton.gameObject.transform.position = new Vector2(0, 0);
    }
}
