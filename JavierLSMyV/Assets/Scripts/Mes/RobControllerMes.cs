/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/* Script desarrollado por Javier López Sánchez */
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RobControllerMes : MonoBehaviour
{

    /* VARIABLES */

    // VARIABLES VISIBLES DESDE EL EDITOR
    [SerializeField] private Sprite[] ImagenesRob;  // Variable para almacenar los "Sprites" de Rob el robot

    // VARIABLES NO VISIBLES DESDE EL EDITOR

    private GameObject data_entry;  // GameObject para almacenar el "Input field" y poder activarlo dinámicamente desde este script
    private GameObject pantalla;  // GameObject para el fading de la escena

    private bool can_press_enter;  // Flag para controlar que se puede introducir el texto

    private string mes_temp;  // Variable para almacenar el mes de forma temporal
    private int cardinal_mes_temp;  // Variable para almacenar el cardinal del mes de forma temporal

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* FUNCIONES  BÁSICAS */

    // START
    // Start is called before the first frame update
    void Start()
    {

        // Inicialización de la pantalla
        pantalla = GameObject.Find("Screen");

        // Aparición de la escena (fading)
        pantalla.GetComponent<RawImage>().canvasRenderer.SetAlpha(1.0f);
        pantalla.GetComponent<RawImage>().CrossFadeAlpha(0.0f, 2.0f, false);

        // Inicialización del Input Field
        data_entry = GameObject.Find("DataEntry");  // Guardar GameObject del "Input Field"
        data_entry.gameObject.SetActive(false);  // Deshabilitar "Input Field"

        // Inicialización de flags
        can_press_enter = false;  // No se puede pulsar "Enter" desde el inicio

        // Rutina para mover a Rob mientras habla
        StartCoroutine(PresentacionRob());

    }

    // UPDATE
    // Update is called once per frame
    void Update()
    {
        if (can_press_enter && Input.GetKey(KeyCode.Return))  // Comprobar en cada "frame" si se puede pulsar "Enter" y en caso afirmativo, si se ha pulsado
        {

            // Obtener el cardinal de forma temporal para decidir la siguiente línea de diálogo
            mes_temp = data_entry.GetComponent<TMP_InputField>().text;
            if (GameObject.Find("Main") != null) cardinal_mes_temp = GameObject.Find("Main").GetComponent<Mes>().ObtenerCardinal(mes_temp);

            if (cardinal_mes_temp == -1) StartCoroutine(MesIncorrecto());  // Si el mes es incorrecto llamar a la rutina de mes incorrecto
            else
            {

                // DESHABILITAR ENTRADA DE TEXTO
                can_press_enter = false; // Prohibir pulsar Enter
                data_entry.gameObject.SetActive(false);  // Desctivar entrada de texto
                data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto

                if (GameObject.Find("Main") != null) GameObject.Find("Main").GetComponent<Mes>().ObtenerParidad(cardinal_mes_temp);
            }

        }
    }

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* RUTINAS */

    // RUTINA INICIAL PARA MOVER A ROB
    private IEnumerator PresentacionRob()
    {

        yield return new WaitForSeconds(2.0f);  // Esperar fading

        GetComponents<AudioSource>()[0].Play();  // Poner clip introductorio

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "¡Hola!";  // Primer mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.25f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Introduce...";  // Segundo mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.3f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Un mes";  // Tercer mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.25f);

        // HABILITAR ENTRADA DE TEXTO
        data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto
        data_entry.gameObject.SetActive(true);  // Activar entrada de texto
        can_press_enter = true; // Permitir pulsar Enter

    }

    // RUTINA A SEGUIR SI EL MES ES PAR (PÚBLICA PARA SER INVOCADA DESDE EL SCRIPT "MES")
    public IEnumerator MesPar()
    {

        GetComponents<AudioSource>()[1].Play();  // Poner clip de mes par
        Debug.Log("Es... ¡Par!");  // Escribir que el mes es par en la consola de Debug
        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Es... ¡Par!";  // Escribir que el mes es par por pantalla

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Es...";  // Primer mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.3f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "¡Par!";  // Segundo mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);

    }

    // RUTINA A SEGUIR SI EL MES ES IMPAR (PÚBLICA PARA SER INVOCADA DESDE EL SCRIPT "MES")
    public IEnumerator MesImpar()
    {

        GetComponents<AudioSource>()[2].Play();  // Poner clip de mes impar
        Debug.Log("Es... ¡Impar!");  // Escribir que el mes es impar en la consola de Debug
        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Es... ¡Impar!";  // Escribir que el mes es impar por pantalla

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Es...";  // Primer mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.5f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "¡Impar!";  // Segundo mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];

    }

    // RUTINA A SEGUIR SI EL MES ES INCORRECTO
    private IEnumerator MesIncorrecto()
    {

        Debug.Log(data_entry.GetComponent<TMP_InputField>().text);  // Escribir la entrada de texto en la consola de Debug

        // DESHABILITAR ENTRADA DE TEXTO
        can_press_enter = false; // Prohibir pulsar Enter
        data_entry.gameObject.SetActive(false);  // Desctivar entrada de texto
        data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto

        GetComponents<AudioSource>()[3].Play();  // Poner clip de mes incorrecto

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "¡Error!";  // Primer mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[3];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.5f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "¡Error!";  // Segundo mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[3];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.15f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Eso no es un mes...";  // Tercer mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[3];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[3];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[3];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[3];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[2];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[3];
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "";  // Restablecer texto

        // REHABILITAR ENTRADA DE TEXTO
        data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto
        data_entry.gameObject.SetActive(true);  // Activar entrada de texto
        can_press_enter = true; // Permitir pulsar Enter

    }

}

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
