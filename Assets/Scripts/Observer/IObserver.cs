namespace Assets.Scripts.Observer
{
    public interface IObserver
    {
    /// <summary>
    /// Appelé en cas d'évènement
    /// </summary>
        public void Update(Observable observable);
    }
}