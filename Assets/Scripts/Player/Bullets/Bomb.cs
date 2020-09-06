using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Bullet
{
    [SerializeField] private GameObject _explosion;
    private List<Health> _aiInRange = new List<Health>();

    protected override void Update()
    {
        _speed -= Time.deltaTime * 25.0f;
        transform.Translate(_direction * _speed * Time.deltaTime);

        if (_speed <= 0)
        {
            _aiInRange.ForEach(x => x.Damage((int)_gun.Damage.CurrentLevel.Value));
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnterListener(Collider other)
    {
        if (other.GetComponent<AI_Base>())
        {
            _aiInRange.Add(other.GetComponent<Health>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _aiInRange.Remove(other.GetComponent<Health>());
    }
}
