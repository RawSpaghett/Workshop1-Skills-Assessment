using UnityEngine;

[CreateAssetMenu(fileName = "NewAmmoData", menuName = "AmmoData")]
public class AmmoData : ScriptableObject
{
    //raw data
    [SerializeField] private float collisionDamage;
    [SerializeField] private float explosionDamage = 0;
    [SerializeField] private float explosionRadius = 0;
    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float turnRate;

    //getters
    public float CollisionDamage => collisionDamage;
    public float ExplosionDamage => explosionDamage;
    public float ExplosionRadius => explosionRadius;
    public float ForwardAcceleration => forwardAcceleration;
    public float TurnRate => turnRate;
}