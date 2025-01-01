using ContactManager.View.States;

namespace ContactManager.View
{
    public interface IUIStateController
    {
        public void SetState(Type type);
        public void Stop();
    }
}