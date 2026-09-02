using Unity.VisualScripting;
using UnityEngine;
public enum EAmmoType{Missile};

public abstract class AmmoBase: MonoBehaviour
{
    //Ammo stats
    [SerializeField] protected AmmoData ammoData;
    protected Rigidbody rb;
    protected bool isFired = false;

    //Methods
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.detectCollisions = false;
        rb.isKinematic = true;
    }

    protected virtual void ProjectileMovement() //forward movement
    {
        //send missile forward via rigidbody
        rb.AddRelativeForce(Vector3.forward * ammoData.ForwardAcceleration,ForceMode.Force);
    }

    protected virtual void FixedUpdate()
    {
        if(isFired)
        {
            ProjectileMovement();
        }
    }

    public virtual void Fire()
    {
        isFired = true;
        transform.SetParent(null);
        rb.detectCollisions = true;
        rb.isKinematic = false;
    }

    protected abstract void OnCollisionEnter(Collision collision);
    





    

}
