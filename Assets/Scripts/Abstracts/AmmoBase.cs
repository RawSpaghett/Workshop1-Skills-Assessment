using Unity.VisualScripting;
using UnityEngine;
public enum EAmmoType{Missile};

public abstract class AmmoBase: MonoBehaviour
{
    //Ammo stats
    public AmmoData ammoData;
    protected Rigidbody rb;
    private bool isFired = true;

    //Methods
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.SetParent(null);
        /*
        rb.detectCollisions = false;
        rb.isKinematic = true;
        */
    }

    public virtual void ProjectileMovement()
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
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        
        isFired = false;
        
    }





    

}
