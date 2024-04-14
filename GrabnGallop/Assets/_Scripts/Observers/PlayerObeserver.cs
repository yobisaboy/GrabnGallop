using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObeserver : MonoBehaviour, IObserver
{
    [SerializeField] private PlayerController _playerSubject;
    void Awake()
    {
        _playerSubject =
          GameObject.FindGameObjectWithTag("Player").
          GetComponent<PlayerController>();
    }
    void OnEnable()
    {
        _playerSubject.AddObserver(this);
    }
    void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }
    public void OnPlayerNotify(PlayerEnums playerEnums)
    {
        switch (playerEnums)
        {
            case PlayerEnums.Move:
                
                break;
            case PlayerEnums.Gallop:

                break;
            case PlayerEnums.Grab:

                break;
            case PlayerEnums.Withdraw:

                break;
            case PlayerEnums.Died:

                break;
            default:
                break;
        }
    }
    public void OnEnemyNotify(EnemyEnums enemyEnums)
    {

    }
    public void OnTargetNotify(TargetEnums targetEnums)
    {

    }
}
