using System.Collections;
using System.Collections.Generic;
using _Game.Script.Manager;
using _UI.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MainMenu>().OnMainScreenOn();
        //CharacterManager.Ins.CollectAll();
        Close(0);
    }
    
    public void SetScore(int score)
    {
        this.score.text = score.ToString();
    }
    
}
