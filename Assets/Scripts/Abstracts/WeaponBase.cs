using UnityEngine;

public abstract class WeaponBase: MonoBehaviour, IWeapon 
{
    protected int curCapacity = 0;
    [SerializeField] protected WeaponData weaponStats; //see weaponData

    void Awake()
    {
        curCapacity = weaponStats.MaxCapacity; //instantiate fully loaded
    }

    //interface methods
    public virtual void PrimaryFire()//LMB
    {
        //call fire command on ammo
    } 
    public virtual void SecondaryFire()
    {
        
    }
    
    public virtual void Reload()//R
    {
        
    } 
}
