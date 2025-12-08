using UnityEngine;

public class WateringCanPour : MonoBehaviour
{
    [SerializeField] ParticleSystem waterParticles;
    [SerializeField] Transform canTransform;

    void Update()
    {
        float pourAngle = Vector3.Angle(canTransform.forward, Vector3.down);
        bool isPouring = pourAngle < 60f;

        if (isPouring && !waterParticles.isPlaying)
            waterParticles.Play();
        else if (!isPouring && waterParticles.isPlaying)
            waterParticles.Stop();
    }
}