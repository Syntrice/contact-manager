using ContactManager.Services.UI.States;

namespace ContactManager.Services.UI
{
    public interface IUIStateController
    {
        public void SetState<State>() where State : IUIState;
        public void Stop();
    }
}