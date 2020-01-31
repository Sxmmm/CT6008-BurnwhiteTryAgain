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


    public override void AbilitySetUp(Boss boss)
    {
        this.boss = boss;
        lastShotTime = 0f;


    }

    public override void AbilityStart()
    {


    }

    // Update is called once per frame
    public override void AbilityUpdate()
    {

    }

    public override void StopAbility()
    {

    }

    private void Shoot()
    {
        BossBullet bullet = Instantiate(prefabBossBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation, null);
        bullet.Fire(shotdamage, shotSpeed);
    }

}
