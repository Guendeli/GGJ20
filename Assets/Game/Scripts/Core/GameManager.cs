using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    None,
    Success,
    Dead
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int _steps;
    private bool _suceeded;
    private bool _isDead;
    private GameStatus _status;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _status = GameStatus.None;
    }

    public void ValidateStep()
    {
        _steps++;
        if(_steps >= 3)
        {
            SetSuccess();
        }
    }

    public void SetSuccess()
    {
        _suceeded = true;
        _status = GameStatus.Success;
    }

    public void SetDead()
    {
        _isDead = true;
        _status = GameStatus.Dead;
    }

    public GameStatus GetStatus()
    {
        return _status;
    }


}
