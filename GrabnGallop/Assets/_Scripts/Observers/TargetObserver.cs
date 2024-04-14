using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObserver : MonoBehaviour, IObserver
{
    [SerializeField] private TargetController _targetSubject;
    void Awake()
    {
        _targetSubject =
          GameObject.FindGameObjectWithTag("Target").
          GetComponent<TargetController>();
    }
    void OnEnable()
    {
        _targetSubject.AddObserver(this);
    }
    void OnDisable()
    {
        _targetSubject.RemoveObserver(this);
    }
    public void OnPlayerNotify(PlayerEnums playerEnums)
    {

    }
    public void OnEnemyNotify(EnemyEnums enemyEnums)
    {

    }
    public void OnTargetNotify(TargetEnums targetEnums)
    {
        switch (targetEnums)
        {
            case TargetEnums.Inactive:

                break;
            case TargetEnums.Active:

                break;
            case TargetEnums.Grabbed:

                break;
            default:
                break;
        }
    }
}
