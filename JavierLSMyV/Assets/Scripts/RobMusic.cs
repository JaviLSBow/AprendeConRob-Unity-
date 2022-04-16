/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/* Script desarrollado por Javier L�pez S�nchez */
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobMusic : MonoBehaviour
{
    /* FUNCIONES B�SICAS */

    // START
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Establecer que este objeto no ser� destruido en el cambio de escena para mantener la m�sica sonando.
        StartCoroutine(MusicaRobStart());  // Llamada a la rutina para iniciar la m�sica.
    }

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* RUTINAS PARA CONTROLAR LA M�SICA */

    // RUTINA PARA INICIAR LA M�SICA
    private IEnumerator MusicaRobStart()
    {

        GetComponents<AudioSource>()[0].Play();  // Iniciar pista 1

        yield return new WaitForSeconds(GetComponents<AudioSource>()[0].clip.length - 1.85f);  // Esperar antes del loop

        StartCoroutine(MusicaRob());  // Rutina del loop

    }

    // RUTINA PARA HACER EL LOOP DE LA M�SICA (NO VALE SOLO CON LOOP PORQUE HAY QUE INICIAR LA MELOD�A DE NUEVO MIENTRAS FINALIZA LA ANTERIOR)
    private IEnumerator MusicaRob()
    {

        GetComponents<AudioSource>()[1].Play();  // Iniciar pista 2

        yield return new WaitForSeconds(GetComponents<AudioSource>()[0].clip.length - 1.35f);  // Esperar antes del loop

        GetComponents<AudioSource>()[0].Play();  // Iniciar pista 1

        yield return new WaitForSeconds(GetComponents<AudioSource>()[0].clip.length - 1.35f);  // Esperar antes del loop

        StartCoroutine(MusicaRob());  // Rutina del loop

    }
}

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
