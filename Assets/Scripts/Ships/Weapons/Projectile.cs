using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed;

    public string Id => _id;

    private void Start()
    {
        _rigidBody.velocity = transform.up * _speed;
        StartCoroutine(DestroyIn(3));
    }

    private IEnumerator DestroyIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
