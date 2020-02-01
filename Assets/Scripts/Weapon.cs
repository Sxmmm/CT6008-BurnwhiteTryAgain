//Sam Baker
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.05f;
    [SerializeField] private float damage = 5;
    public GameObject orientaion;
    public GameObject bulletObject;
    public WEAPON_TYPE weaponType;
    public bool isShooting;
    private float timer;

    private void Start() => timer = fireRate;

    private void Update() {
        if (isShooting) {
            //Shoot
            if (GameObject.FindGameObjectWithTag("Player") != null) {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerZoomIn>().zoomIn == false) {
                    isShooting = false;
                    return;
                }
                timer -= Time.deltaTime;
                if (timer <= 0.0f) {
                    ShootAction();
                    timer = fireRate;
                }
            }
        } else {
            //No Shoot
        }
    }

    private void ShootAction() {
        GameObject bullet = Instantiate(bulletObject, orientaion.transform.position, orientaion.transform.rotation);
        bullet.GetComponent<Bullet>().myDamage = damage;
    }

    public void ShootTrigger(InputAction.CallbackContext ctx) {
        if (ctx.performed) {
            if (isShooting) {
                isShooting = false;
            } else {
                if (GameObject.FindGameObjectWithTag("Player") != null) {
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerZoomIn>().zoomIn) {
                        isShooting = true;
                    } else {
                        return;
                    }
                }
            }
        }
    }

    public enum WEAPON_TYPE {
        AUTOMATIC,
        SINGLE_FIRE
    };
}
