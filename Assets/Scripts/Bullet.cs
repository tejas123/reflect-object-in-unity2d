using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    #region PUBLIC-PROPERTIES
    public float bulletSpeed;
    #endregion

    #region PRIVATE-PROPERTIES
    #endregion

    #region UNITY-CALLBACKS
    void OnEnable()
    {
        rigidbody2D.velocity = transform.right * bulletSpeed;
    }
	
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Wall"))
            CollisionWithWall(other);
    }
    #endregion

    #region PRIVATE-MEHODS
    void CollisionWithWall(Collision2D other)
    {
        Vector3 reflectedPosition = Vector3.Reflect(transform.right, other.contacts[0].normal);
        rigidbody2D.velocity = (reflectedPosition).normalized * bulletSpeed;

        Vector3 dir = rigidbody2D.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rigidbody2D.MoveRotation(angle);
    }
    #endregion
}
