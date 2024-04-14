using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    public void OnPlayerNotify(PlayerEnums playerEnums);
    public void OnEnemyNotify(EnemyEnums enemyEnums);
    public void OnTargetNotify(TargetEnums targetEnums);
}
