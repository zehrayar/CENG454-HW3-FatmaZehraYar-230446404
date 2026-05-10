using UnityEngine;

public class PiercingDecorator : WeaponDecorator
{
    public PiercingDecorator(IWeapon inner) : base(inner) { }

    public override void Fire(Vector2 origin, Vector2 direction)
    {
        // inner.Fire çağırıp ardından spawn olan bullet'ları piercing yapacağız.
        // En temiz yol: spawn callback'i ile yapmak ama burada kısa tutmak için
        // BulletPool'u doğrudan kullanıyoruz.
        Bullet b = PoolManager.Instance.BulletPool.Get(origin, Quaternion.identity);
        b.Launch(direction, inner.Damage, isPiercing: true);
    }
}