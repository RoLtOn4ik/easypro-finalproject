using UnityEngine;

public class PotionExplosion : MonoBehaviour
{
    private Vector3 _scale;
    private float _explotionSpeed = 12;
    private float _maxSize = 4;

    void Update()
    {
        if (_scale.x > _maxSize)
        {
            Destroy(gameObject);
        }
        
        _scale = transform.localScale + Vector3.one * _explotionSpeed * Time.deltaTime;

        transform.localScale = _scale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(enemy.gameObject);
        }
    }
}
