namespace Assets.Scripts.Observer
{
    public interface IObserver
    {
        public void Update(IObservable observable);
    }
}