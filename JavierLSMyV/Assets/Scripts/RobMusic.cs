/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/* Script desarrollado por Javier López Sánchez */
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobMusic : MonoBehaviour
{
    /* FUNCIONES BÁSICAS */

    // START
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Establecer que este objeto no será destruido en el cambio de escena para mantener la música sonando.
        StartCoroutine(MusicaRobStart());  // Llamada a la rutina para iniciar la música.
    }

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* RUTINAS PARA CONTROLAR LA MÚSICA */

    // RUTINA PARA INICIAR LA MÚSICA
    private IEnumerator MusicaRobStart()
    {

        GetComponents<AudioSource>()[0].Play();  // Iniciar pista 1

        yield return new WaitForSeconds(GetComponents<AudioSource>()[0].clip.length - 1.85f);  // Esperar antes del loop

        StartCoroutine(MusicaRob());  // Rutina del loop

    }

    // RUTINA PARA HACER EL LOOP DE LA MÚSICA (NO VALE SOLO CON LOOP PORQUE HAY QUE INICIAR LA MELODÍA DE NUEVO MIENTRAS FINALIZA LA ANTERIOR)
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
