using UnityEngine;
using System.Collections;

public class SetAim : MonoBehaviour {

    public Transform target;

    public Bullet bullet;

    public bool canFire;
	// Use this for initialization
	void Start () {
        canFire = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        ProcessInput();
	}

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canFire)
            SetTarget();

        if (Input.GetKeyUp(KeyCode.Mouse0))
            Fire();
    }

    void SetTarget()
    {
        Vector3 tempTargetPosition;

        target.gameObject.SetActive(true);

        tempTargetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tempTargetPosition.z = 0;
        target.transform.position = tempTargetPosition;

        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        
    }

    void Fire()
    {
        canFire = false;
        target.gameObject.SetActive(false);
        bullet.enabled = true;
    }
}
