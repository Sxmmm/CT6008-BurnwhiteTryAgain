//TOYE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAbility : MonoBehaviour
{
    protected Boss boss;
    //protected Player player;
    public virtual void AbilitySetUp(Boss boss)
    {
        this.boss = boss;
    }

    public abstract void AbilityStart();

    // Update is called once per frame
    public abstract void AbilityUpdate();

    public abstract void StopAbility();

}
