using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    public void OnPlayerNotify(PlayerEnums playerEnums);
    public void OnNotify(EnemyEnums enemyEnums);
    public void OnNotify(TargetEnums targetEnums);
}
