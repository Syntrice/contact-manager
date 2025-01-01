using ContactManager.View.States;

namespace ContactManager.View
{
    public interface IUIStateController
    {
        public void SetState<State>() where State : IUIState;
        public void Stop();
    }
}