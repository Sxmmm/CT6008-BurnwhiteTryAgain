//TOYE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityShoot : BossAbility
{
    [SerializeField] private BossBullet prefabBossBullet;
    [SerializeField] private float shootCoolDown;
    private float lastShotTime;

    private float shotdamage;
    private float shotSpeed;

    private Transform bulletSpawnPoint;
    private Transform turretHeadRotatePoint;
    private Transform turretHeadAimPoint;

    private float rotateTurretSpeed;
    private float pivotTurretSpeed;


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
        //No idea if this will work
        Vector3 targetPosition = playerMovement.transform.position + (Vector3.Distance(this.transform.position, playerMovement.transform.position) * Time.deltaTime * shotSpeed * playerMovement.playerAccelaration);

        float targetTurretRotateYangle = AngleBetweenPoints(turretHeadRotatePoint.transform.position, targetPosition);
        turretHeadRotatePoint.rotation = Quaternion.Euler(new Vector3(0f, Mathf.MoveTowardsAngle(turretHeadRotatePoint.rotation.y, targetTurretRotateYangle, rotateTurretSpeed * Time.deltaTime), 0f));

    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }




}