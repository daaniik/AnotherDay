using UnityEngine;

public class WateringCanPour : MonoBehaviour
{
    [SerializeField] ParticleSystem waterParticles;
    [SerializeField] Transform canTransform; // drag the watering can mesh here

    void Update()
    {
        // Get the local Euler angle around X (tilt forward/back)
        float tilt = canTransform.localEulerAngles.x;

        // Convert 0-360 range → -180 to 180 so 270 becomes -90 etc.
        if (tilt > 180f) tilt -= 360f;

        // Pouring range: 120 to 220 (roughly upside-down to forward tilt)
        bool isPouring = tilt > 120f && tilt < 220f;

        if (isPouring && !waterParticles.isPlaying)
            waterParticles.Play();
        else if (!isPouring && waterParticles.isPlaying)
            waterParticles.Stop();
    }
}