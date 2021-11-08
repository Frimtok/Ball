using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int Health;
    [SerializeField] private Interface _interface; 
    public static int BestScore { get; private set; }
    [HideInInspector]public bool IsClick;
    private int Score;
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void StateGame()
    {
        if (IsClick)
        {
            Play();
        }
        else
        {
            Pouse();
        }
    }
    private void Start()
    {
        Play();
        Ball.OnAddScore += AddScore;
        DownPlatfotm.OnDamage += DecrementHealth;
        Score = 0;
        _interface.ShowHealth(Health);
        _interface.ShowScore(Score);
    }
    private void Update()
    {
        if (Health <= 0)
        {
            Health = 0;
            Defeat();
            _interface.ShowDeafe();
            _interface.ShowHealth(Health);
            Pouse();
        }
    }
    private void Pouse()
    {
        MoveTime(0);
        IsClick = true;
        _interface.ShowPouse();
    }
    private void Play()
    {
        MoveTime(1);
        IsClick = false;
        _interface.ShowPlay();
    }
    private void MoveTime(float timeMovement)
    {
        Time.timeScale = timeMovement;
    }
    private void Defeat()
    {
        if (BestScore < Score)
        {
            BestScore = Score;
            _interface.ShowDeafe();
        }
    }
    private void AddScore(int score)
    {
        Score += score;
        _interface.ShowScore(score);
    }
    private void DecrementHealth(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
            _interface.ShowHealth(Health);
        }
    }
    
}
