using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moose : Animal // INHERITANCE
{

    public float MooseSpeed;
    public float MooseHealth;
    public int Toughness;

    // Start is called before the first frame update
    void Start()
    {
        Speed = MooseSpeed;
        Health = MooseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    public override void Damage(Bone bone) // POLYMORPHISM
    {
        int RawDamage = bone.Damage;
        int DamageDealt = RawDamage - Toughness;
        base.Damage(DamageDealt);
    }

    public override void Damage(Pizza pizza) // POLYMORPHISM
    {
        int RawDamage = pizza.Damage;
        int DamageDealt = RawDamage - Toughness;
        base.Damage(DamageDealt);
    }

    void OnTriggerEnter(Collider other)
    {
        // Instead of destroying the projectile when it collides with an animal
        //Destroy(other.gameObject); 

        // Just deactivate the food and destroy the animal
        other.gameObject.SetActive(false);
        if (other.CompareTag("Bone"))
        {
            Damage(other.GetComponent<Bone>()); // POLYMORPHISM
        }
        else
        {
            Damage(other.GetComponent<Pizza>()); // POLYMORPHISM
        }

    }
}
