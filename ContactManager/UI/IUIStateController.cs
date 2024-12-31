using ContactManager.UI.States;

namespace ContactManager.UI
{
    public interface IUIStateController
    {
        public void SetState<State>() where State : IUIState;
        public void Stop();
    }
}