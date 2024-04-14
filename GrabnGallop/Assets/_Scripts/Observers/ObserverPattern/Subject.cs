using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    [SerializeField] private List<IObserver> _observers = new();

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }   

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    // This method will be called when the subject's state changes
    public void PlayerNotifyObservers(PlayerEnums playerEnums)
    {
        //another way of a method call for each list item
        _observers.ForEach((_observer) =>
        {
            _observer.OnPlayerNotify(playerEnums);
        });
    }
    public void EnemyNotifyObservers(EnemyEnums enemyEnums)
    {
        //another way of a method call for each list item
        _observers.ForEach((_observer) =>
        {
            _observer.OnEnemyNotify(enemyEnums);
        });
    }
    public void TargetNotifyObservers(TargetEnums targetEnums)
    {
        //another way of a method call for each list item
        _observers.ForEach((_observer) =>
        {
            _observer.OnTargetNotify(targetEnums);
        });
    }
}
