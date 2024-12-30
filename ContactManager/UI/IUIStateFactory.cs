namespace ContactManager.UI
{
    public interface IUIStateFactory 
    {
        IUIState GetInstance<State>() where State : IUIState;
    }
}
