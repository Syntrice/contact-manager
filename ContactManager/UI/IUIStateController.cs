namespace ContactManager.UI
{
    public interface IUIStateController
    {
        public Task SetState<State>() where State : IUIState;
    }
}