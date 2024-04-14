using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObserver : MonoBehaviour, IObserver
{
    [SerializeField] private EnemyController _enemySubject;
    void Awake()
    {
        _enemySubject =
          GameObject.FindGameObjectWithTag("Enemy").
          GetComponent<EnemyController>();
    }
    void OnEnable()
    {
        _enemySubject.AddObserver(this);
    }
    void OnDisable()
    {
        _enemySubject.RemoveObserver(this);
    }
    public void OnPlayerNotify(PlayerEnums playerEnums)
    {

    }
    public void OnEnemyNotify(EnemyEnums enemyEnums)
    {
        switch (enemyEnums)
        {
            case EnemyEnums.Move:

                break;
            case EnemyEnums.Catch:

                break;
            default:
                break;
        }
    }
    public void OnTargetNotify(TargetEnums targetEnums)
    {

    }
}
