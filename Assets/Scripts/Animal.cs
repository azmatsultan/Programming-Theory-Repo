using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float m_Speed; 

    public float Speed // ENCAPSULATION
    {
        get
        {
            return m_Speed;
        }
        set
        {
            m_Speed = value;
        }
    }

    [SerializeField]
    private float m_Health; 

    public float Health   // ENCAPSULATION
    {
        get
        {
            return m_Health;
        }
        set
        {
            m_Health = value;
        }
    }
    
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Damage( Bone bone) // POLYMORPHISM
    {
        m_Health -= bone.Damage;
    }

    public virtual void Damage(Pizza pizza) // POLYMORPHISM
    {
        m_Health -= pizza.Damage;
    }

    public virtual void Damage(int value) // POLYMORPHISM
    {
        m_Health -= value;
        if( m_Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
