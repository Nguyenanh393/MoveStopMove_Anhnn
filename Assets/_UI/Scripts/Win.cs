using System.Collections;
using System.Collections.Generic;
using _UI.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        Close(0);
    }
    
    public void SetScore(int score)
    {
        this.score.text = score.ToString();
    }
    
}
