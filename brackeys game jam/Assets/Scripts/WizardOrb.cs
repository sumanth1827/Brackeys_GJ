using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardOrb : MonoBehaviour
{
    // Hunter bullet references
    private Rigidbody2D bulletRb;

    // hunter parameter references
    [SerializeField]
    private float bulletSpeed;

    private Vector2 bulletMovementDir;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();

        bulletMovementDir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)this.gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        BulletMovement();
    }

    private void BulletMovement()
    {
        bulletRb.MovePosition((Vector2)this.transform.position + bulletMovementDir.normalized * bulletSpeed * Time.fixedDeltaTime);
    }
}
