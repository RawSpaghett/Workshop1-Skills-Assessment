using UnityEngine;
public enum EAmmoType{Missile};

public abstract class AmmoBase: MonoBehaviour
{
    //Ammo stats
    public AmmoData ammoData;
    protected Rigidbody rb;
    private bool isFired = true;

    //Methods
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.SetParent(null);
    }

    public virtual void ProjectileMovement()
    {
        //send missile forward via rigidbody
        rb.AddForce(transform.forward * ammoData.ForwardAcceleration,ForceMode.Force);
    }

    void FixedUpdate()
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
        //damage
        //return object to pool
    }





    

}
