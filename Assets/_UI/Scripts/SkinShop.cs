namespace _UI.Scripts
{
    public class SkinShop : UICanvas
    {
        public void ExitButton()
        {
            UIManager.Ins.OpenUI<MainMenu>();
            Close(0);
        }
    
        
    }
}
