//TOYE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityShoot : BossAbility
{
    [SerializeField] private BossBullet prefabBossBullet;
    [SerializeField] private float shootCoolDown;
    private float lastShotTime;

    [SerializeField] private float shotdamage;
    [SerializeField] private float shotSpeed;

    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform turretHeadRotatePoint;
    [SerializeField] private Transform turretHeadAimPoint;

    [SerializeField] private float rotateTurretSpeed;
    [SerializeField] private float pivotTurretSpeed;


    public override void AbilitySetUp(Boss boss, MultiMovementV2 multiMovementV2)
    {
        base.AbilitySetUp(boss, multiMovementV2);
        this.boss = boss;
        lastShotTime = 0f;


    }

    public override void AbilityStart()
    {


    }

    // Update is called once per frame
    public override void AbilityUpdate()
    {
        MoveTowardsPlayer();
        AimAtPlayer();
        TryShoot();
    }

    public override void StopAbility()
    {

    }


    private void MoveTowardsPlayer()
    {

    }

    private void TryShoot()
    {
        if (lastShotTime + shootCoolDown < Time.time)
        {
            lastShotTime = Time.time;
            BossBullet bullet = Instantiate(prefabBossBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation, null);
            bullet.Fire(shotdamage, shotSpeed);
        }
    }


    private void AimAtPlayer()
    {

        //First part is rotating turret head to look at player on y axis

        //No idea if this will work but should incorporate player accelleration?
        Vector3 targetPosition = playerMovement.transform.position + (Vector3.Distance(this.transform.position, playerMovement.transform.position) * Time.deltaTime * shotSpeed * playerMovement.playerAccelaration);

        Vector3 lookPos = new Vector3(targetPosition.x, turretHeadRotatePoint.position.y, targetPosition.z);
        Vector3 lookDir = (lookPos - turretHeadRotatePoint.position).normalized;
        Quaternion look = Quaternion.LookRotation(lookDir, transform.up);
        turretHeadRotatePoint.rotation = Quaternion.Lerp(turretHeadRotatePoint.rotation, look, rotateTurretSpeed * Time.deltaTime);

        //second part is pivoting turret arm to look at player on z axis (up down)

        Vector3 pivotLookPos = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);
        Vector3 pivotLookDir = (pivotLookPos - turretHeadAimPoint.position).normalized;
        Quaternion pivot = Quaternion.LookRotation(pivotLookDir, transform.right);

        float xClamp = Mathf.Clamp(pivot.eulerAngles.x, -30, 30);
        pivot = Quaternion.Euler(xClamp, 0, 0);

        turretHeadAimPoint.rotation = Quaternion.Lerp(turretHeadAimPoint.rotation, pivot, pivotTurretSpeed * Time.deltaTime);

    }

    float AngleBetweenPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg;
    }
}