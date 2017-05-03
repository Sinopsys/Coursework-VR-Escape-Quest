using UnityEngine;

public class FindCollideParticles : MonoBehaviour
{

    public float burstEnergy = 10F;
    public Transform explosionObject;

    public void LateUpdate()
    {
        var theParticles = GetComponent<ParticleEmitter>().particles;
        var liveParticles = new int[theParticles.Length];
        var particlesToKeep = 0;
        for (int i = 0; i < GetComponent<ParticleEmitter>().particleCount; ++i)
        {
            if (theParticles[i].energy > burstEnergy)
            {
                theParticles[i].color = Color.yellow;
                if (explosionObject)
                    Instantiate(explosionObject,
                        theParticles[i].position,
                        Quaternion.identity);
            }
            else
                liveParticles[particlesToKeep++] = i;
        }
        var keepParticles = new Particle[particlesToKeep];
        for (int j = 0; j < particlesToKeep; ++j)
            keepParticles[j] = theParticles[liveParticles[j]];
        GetComponent<ParticleEmitter>().particles = keepParticles;
    }
}


// EOF
