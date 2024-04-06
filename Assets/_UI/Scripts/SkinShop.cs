using System.Collections;
using System.Collections.Generic;
using _UI.Scripts;
using UnityEngine;

public class SkinShop : UICanvas
{
    public void ExitButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        Close(0);
    }
    
}
