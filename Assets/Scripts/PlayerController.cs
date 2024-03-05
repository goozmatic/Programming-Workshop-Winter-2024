using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float MinX;
    public float MaxX;

    [SerializeField]
    public GameObject Projectile;

    void Update()
    {
        HandleMovement();
        BasicShooting();
    }

    void HandleMovement()
    {
        Vector3 moveDir = Vector3.zero;

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > MinX)
        {
            moveDir = Vector3.left;
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < MaxX)
        {
            moveDir = Vector3.right;
        }

        transform.Translate (moveDir * MoveSpeed * Time.deltaTime);
    }

    void BasicShooting()
    {
        if ((Input.GetKeyDown(KeyCode.J)) || Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(Projectile, gameObject.transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileTraits>().HasPlayerSpawned = true;
        }
    }
}
