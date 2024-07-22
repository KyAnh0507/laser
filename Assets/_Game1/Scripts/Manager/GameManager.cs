using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { GAMEPLAY, PAUSE, FINISH }

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    public GameState state;

    public bool IsState(GameState state) => this.state == state;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.OpenUI<UILoading>().OpenUILoading();
    }

    public void ChangeState(GameState state)
    {
        this.state = state;
    }
}
