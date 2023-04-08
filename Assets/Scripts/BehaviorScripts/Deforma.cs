using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efeito : MonoBehaviour

{

    public MeshRenderer render;

    public Rigidbody body;

    public float intensidade;



    void Start()

    {

        render = GetComponent<MeshRenderer>();

        body = GetComponent<Rigidbody>();

        
        intensidade = 7;

    }



    void Aplica()

    {

        render.material.SetFloat("_Intensidade", intensidade);

    }

    void Processa()
    {
        if (body.velocity.magnitude == 0)
        {
            intensidade += 0.2f;

            if (intensidade >= 9f)
            {
                intensidade = 9f;
            }
        }

        else if (body.velocity.magnitude != 0)
        {
            intensidade-= 0.5f;

            if (intensidade <= 4f)
            {
               intensidade = 4f;
            }
        }
    }
}



