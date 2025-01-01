namespace ContactManager.View
{
    public interface IStateController
    {
        public void SetState(Type type);
        public void Stop();
    }
}