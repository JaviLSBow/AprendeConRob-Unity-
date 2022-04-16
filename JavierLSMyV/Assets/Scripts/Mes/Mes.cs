/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/* Script desarrollado por Javier López Sánchez */
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mes : MonoBehaviour
{
    /* VARIABLES */

    // VARIABLES NO VISIBLES DESDE EL EDITOR
    [SerializeField] private string mes;  // Variable para almacenar el mes y mostrarlo más adelante. En vez de usar getters y setters la establecer como pública esta vez.
    public int cardinal_mes; // Variable de clase para almacenar el cardinal del mes. En vez de usar getters y setters la establecer como pública esta vez.
    [SerializeField] private string paridad_mes;  // Variable auxiliar para mostrar en el editor si el mes es par o impar


/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* OPERACIONES SOBRE EL MES Y SU CARDINAL */

    // FUNCIÓN QUE RECIBE UN MES Y DEVUELVE SU CARDINAL CORRESPONDIENTE
    public int ObtenerCardinal(string mes_introducido)
    {

        // Convertir el mes a minúsculas para permitir al usuario introducirlo con más libertad
        mes = mes_introducido.ToLower();

        // Establecer relación mes-cardinal. Si no existe el mes se marca al cardinal como -1 indicando error.
        if (mes == "enero") cardinal_mes = 1;
        else if (mes == "febrero") cardinal_mes = 2;
        else if (mes == "marzo") cardinal_mes = 3;
        else if (mes == "abril") cardinal_mes = 4;
        else if (mes == "mayo") cardinal_mes = 5;
        else if (mes == "junio") cardinal_mes = 6;
        else if (mes == "julio") cardinal_mes = 7;
        else if (mes == "agosto") cardinal_mes = 8;
        else if (mes == "septiembre") cardinal_mes = 9;
        else if (mes == "octubre") cardinal_mes = 10;
        else if (mes == "noviembre") cardinal_mes = 11;
        else if (mes == "diciembre") cardinal_mes = 12;
        else cardinal_mes = -1;

        // Devolvemos el cardinal
        return cardinal_mes;

    }

    // ACCIÓN PARA CONOCER SI EL MES ES PAR O IMPAR
    public void ObtenerParidad(int cardinal)
    {

        // Comprobamos que el cardinal recibido es el mismo que el almacenado
        if (cardinal_mes == cardinal)
        {
            // Comprobamos si el cardinal es par o impar.
            if (cardinal_mes % 2 == 0)  // Si es par
            {
                if (GameObject.Find("RobController") != null) StartCoroutine(GameObject.Find("RobController").GetComponent<RobControllerMes>().MesPar()); // Activamos la rutina de Rob para meses pares
                paridad_mes = "Es par";  // Escribimos que el mes es par en el editor
            }

            else  // Si es impar
            {
                if (GameObject.Find("RobController") != null) StartCoroutine(GameObject.Find("RobController").GetComponent<RobControllerMes>().MesImpar()); // Activamos la rutina de Rob para meses impares
                paridad_mes = "Es impar";  // Escribimos que el mes es impar en el editor
            }

            Debug.Log("FIN DEL PROGRAMA. PUEDES SALIR CUANDO QUIERAS...");  // Indicamos que el programa se ha acabado. Puedes cerrarlo cuando quieras.

        }

        // Si el cardinal recibido es distinto que el almacenado indicaremos un error interno del sistema
        else Debug.Log("Error Interno del Sistema!!!!");

    }

}

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
