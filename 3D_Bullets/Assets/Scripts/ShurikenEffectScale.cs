using UnityEngine;
using System.Collections;

public class ShurikenEffectScale : MonoBehaviour
{
    // Awake
    void Awake()
    {
        // mul scale to particles
        var particles = this.gameObject.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i].startSize *= m_Scale;
        }
    }

    // member
    public float m_Scale = 1.0f;

    // Awake
    void Awake(float scale)
    {
        // mul scale to particles
        var particles = this.gameObject.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particles.Length; ++i)
        {
            particles[i].startSize *= scale;
        }
    }
}
