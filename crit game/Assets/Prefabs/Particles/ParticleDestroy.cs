using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    [SerializeField] private float destroyAfterSeconds = 0f;
    void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}
