//Sam Baker
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    public float myDamage;

    private void Start() => Destroy(gameObject, 3.0f);

    private void Update() => transform.position += transform.forward * Time.deltaTime * movementSpeed;

    public void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<Enemy>().TakeBulletDamage(myDamage);
        }
    }
}