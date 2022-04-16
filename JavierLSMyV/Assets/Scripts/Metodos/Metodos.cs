/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/* Script desarrollado por Javier López Sánchez */
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metodos : MonoBehaviour
{

    /* VARIABLES */

    // VARIABLES VISIBLES FUERA DEL EDITOR PARA REALIZAR LAS OPERACIONES MATEMÁTICAS
    [SerializeField] private float numero;
    [SerializeField] private int exponente;
    [SerializeField] private float resultado;

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* OPERACIÓN MATEMÁTICA */

    // MULTIPLICACIÓN EXPONENCIAL
    public void Multiplicar()
    {

        // Variable auxiliar para el cálculo
        int exponente_aux;

        // Inicialización de valores
        resultado = numero;
        exponente_aux = exponente;

        // Multiplicar número por si mismo tantas veces como indique el exponente;
        while (exponente_aux > 1)
        {
            resultado *= numero;
            exponente_aux -= 1;
        }

    }

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* GETTERS AND SETTERS */

    // GET NUMERO
    public float GetNumero()
    {
        return numero;
    }

    // GET EXPONENTE
    public float GetExponente()
    {
        return exponente;
    }

    // SET NUMERO
    public void SetNumero(float num)
    {
        numero = num;
    }

    // SET EXPONENTE
    public void SetExponente(int exp)
    {
        exponente = exp;
    }

    // GET RESULTADO
    public float GetResultado()
    {
        return resultado;
    }

    // SET RESULTADO
    public void SetResultado(float res)
    {
        resultado = res;
    }

}

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
