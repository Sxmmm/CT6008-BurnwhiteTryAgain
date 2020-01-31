//TOYE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public float health;
    public float runSpeed;
    public float turnSpeed;


    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Animator animator;

    [SerializeField] private BossAbilityGoHome goHome;
    [SerializeField] private BossAbilityHeal heal;
    [SerializeField] private BossAbilityHeal shoot;

    private enum BossState {
        Idle,
        GoHome,
        Heal,
        ShootAttack,
        MeleeAttack,
        Dead

    }

    private BossState currentState;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChooseAbility()
    {

    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case BossState.Idle:

                break;
            case BossState.GoHome:
                break;
            case BossState.Heal:
                break;
            case BossState.ShootAttack:
                break;
            default:
                break;
        }
    }

    public void SetNavTarget(Vector3 vector3)
    {
        navAgent.enabled = true;
        navAgent.SetDestination(vector3);
    }

    public void TakeDamage(float ammount)
    {
        health -= ammount;
        CheckState();
    }

    private void CheckState()
    {





    }



}
