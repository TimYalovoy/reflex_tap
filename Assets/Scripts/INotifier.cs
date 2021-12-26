using UnityEngine;

public interface INotifier
{
    void Attach(IObserver observer);
    void Notify();
}
