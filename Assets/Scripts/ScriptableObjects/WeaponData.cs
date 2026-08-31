using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField] protected int maxCapacity;
    [SerializeField] protected float fireCooldown;
    [SerializeField] protected float reloadTimer;
    [SerializeField] protected EAmmoType ammoType;

    //getters
    public int MaxCapacity => maxCapacity;
    public float FireCooldown => fireCooldown;
    public float ReloadTimer => reloadTimer;
    public EAmmoType AmmoType => ammoType;
}