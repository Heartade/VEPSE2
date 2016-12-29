using UnityEngine;
using System.Collections;

public abstract class InteractingGameObject : MonoBehaviour {
    
    public ParticleSystem ps;

    protected bool isTrigger = false;

    public void onTrigger()
    {
        ps.Stop();
        isTrigger = true;
    }

    public ParticleSystem getParticleSystem()
    {
        return ps;
    }

    public void setParticleSystem(ParticleSystem p)
    {
        ps = p;
    }
}
