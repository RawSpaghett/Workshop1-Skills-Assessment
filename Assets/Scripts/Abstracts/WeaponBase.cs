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
    public abstract void PrimaryFire(); //lmb
    public abstract void SecondaryFire(); //rmb

    public abstract void Reload(); //r
}
