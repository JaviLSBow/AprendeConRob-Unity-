/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/* Script desarrollado por Javier López Sánchez */
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RobController : MonoBehaviour
{

    /* VARIABLES */

    // VARIABLES VISIBLES DESDE EL EDITOR
    [SerializeField] private Sprite [] ImagenesRob;  // Variable para almacenar los "Sprites" de Rob el robot

    // VARIABLES NO VISIBLES DESDE EL EDITOR

    private GameObject data_entry;  // GameObject para almacenar el "Input field" y poder activarlo dinámicamente desde este script
    private GameObject pantalla;  // GameObject para el fading de la escena

    private bool can_press_enter;  // Flag para controlar que se puede introducir el texto

    private bool is_numero;  // Flag para controlar que lo que puede introducir es el número
    private bool is_exponente;  // Flag para controlar que lo que puede introducir es el exponente
    private bool next_scene;  // Falg para controlar que al pulsar enter se cambie de escene

    private float numero_temp;  // Variable temporal para almacenar el número
    private int exponente_temp;  // Variable temporal para almacenar el número

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
        is_numero = true; // Lo primero que se puede introducir es el número
        is_exponente = false; // Pero todavía no se introduce el exponente
        next_scene = false;  // Ni cambiar de escena

        // Rutina para mover a Rob mientras habla
        StartCoroutine(PresentacionRob());

    }

    // UPDATE
    // Update is called once per frame
    void Update()
    {
        if (can_press_enter && Input.GetKey(KeyCode.Return))  // Comprobar en cada "frame" si se puede pulsar "Enter" y en caso afirmativo, si se ha pulsado
        {

            if (is_numero)  // Comprobar que hay que revisar el número
            {
                // Si el texto es un número se llama a la rutina de número correcto
                if (float.TryParse(data_entry.GetComponent<TMP_InputField>().text.ToString(), out numero_temp)) StartCoroutine(NumeroCorrecto());
                // Si el texto es cualquier otra cosa se llama a la rutina de número incorrecto
                else StartCoroutine(NumeroIncorrecto());
            }

            else if (is_exponente)  // Comprobar que hay que revisar el exponente
            {
                // Si el texto es un número se llama a la rutina de exponente correcto
                if (int.TryParse(data_entry.GetComponent<TMP_InputField>().text.ToString(), out exponente_temp)) StartCoroutine(ExponenteCorrecto());
                // Si el texto es cualquier otra cosa se llama a la rutina de número incorrecto
                else StartCoroutine(NumeroIncorrecto());
            }

            else if (next_scene) StartCoroutine(SiguienteEscena()); // Comprobar si se puede cambiar de escena para iniciar la rutina de cambio de escena

        }
    }

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/

    /* RUTINAS DE ROB */

    // RUTINA INICIAL PARA MOVER A ROB
    private IEnumerator PresentacionRob()
    {

        yield return new WaitForSeconds(2.0f);  // Esperar fading
        
        GetComponents<AudioSource>()[0].Play();  // Poner primer clip

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "¡Hola!";  // Primer mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.5f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Me llamo Rob...";  // Segundo mensaje de texto
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

        GetComponents<AudioSource>()[1].Play();  // Poner segundo clip
        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Y soy tu asistente para esta primera entrega...";  // Tercer mensaje de texto
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
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.3f);

        GetComponents<AudioSource>()[2].Play();  // Poner tercer clip
        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "De la asignatura Desarrollo de Videojuegos I";  // Cuarto mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
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
        yield return new WaitForSeconds(0.15f);
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
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.3f);

        GetComponents<AudioSource>()[3].Play();  // Poner cuarto clip
        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Por favor...";  // Quinto mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(1);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Introduce un número...";  // Sexto mensaje de texto
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
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.3f);

        // HABILITAR ENTRADA DE TEXTO
        data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto
        data_entry.gameObject.SetActive(true);  // Activar entrada de texto
        can_press_enter = true; // Permitir pulsar Enter

        }

    // RUTINA A SEGUIR SI EL NÚMERO ES CORRECTO
    private IEnumerator NumeroCorrecto()
    {

        // DESHABILITAR ENTRADA DE TEXTO
        can_press_enter = false; // Prohibir pulsar Enter
        data_entry.gameObject.SetActive(false);  // Desctivar entrada de texto
        data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto

        if (GameObject.Find("Main") != null) GameObject.Find("Main").GetComponent<Metodos>().SetNumero(numero_temp);  // Almacenar número
        Debug.Log(numero_temp);  // Escribir el número en la consola de Debug

        GetComponents<AudioSource>()[4].Play();  // Poner clip de numero correcto

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "¡Eso es!";  // Primer mensaje de texto
        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.5f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Ahora, debes indicar...";  // Segundo mensaje de texto
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
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.3f);

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Cuantas veces tiene ese número que multiplicarse por sí mismo";  // Tercer mensaje de texto
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
        yield return new WaitForSeconds(0.15f);
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

        // CAMBIO DE DATO A INTRODUCIR
        is_numero = false; // Ya se ha introducido el número
        is_exponente = true; // Ahora se introduce el exponente

        // HABILITAR ENTRADA DE TEXTO
        data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto
        data_entry.gameObject.SetActive(true);  // Activar entrada de texto
        can_press_enter = true; // Permitir pulsar Enter

    }

    // RUTINA A SEGUIR SI EL NÚMERO ES INCORRECTO
    private IEnumerator NumeroIncorrecto()
    {

        Debug.Log(data_entry.GetComponent<TMP_InputField>().text);  // Escribir la entrada de texto en la consola de Debug

        // DESHABILITAR ENTRADA DE TEXTO
        can_press_enter = false; // Prohibir pulsar Enter
        data_entry.gameObject.SetActive(false);  // Desctivar entrada de texto
        data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto

        GetComponents<AudioSource>()[5].Play();  // Poner clip de numero incorrecto

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

        GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Eso no es un número...";  // Tercer mensaje de texto
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

    // RUTINA A SEGUIR SI EL NÚMERO ES CORRECTO
    private IEnumerator ExponenteCorrecto()
    {

        // DESHABILITAR ENTRADA DE TEXTO
        can_press_enter = false; // Prohibir pulsar Enter
        data_entry.gameObject.SetActive(false);  // Desctivar entrada de texto
        data_entry.GetComponent<TMP_InputField>().text = "-";  // Establecer texto por defecto

        if (GameObject.Find("Main") != null) GameObject.Find("Main").GetComponent<Metodos>().SetExponente(exponente_temp);  // Almacenar exponente
        Debug.Log(exponente_temp);  // Escribir el exponente en la consola de Debug

        // Realizar Multiplicación y mostrar resultado
        if (GameObject.Find("Main") != null) GameObject.Find("Main").GetComponent<Metodos>().Multiplicar();
        if (GameObject.Find("Main") != null)  GameObject.Find("RobMessage").GetComponent<TextMeshProUGUI>().text = "Resultado: " +  GameObject.Find("Main").GetComponent<Metodos>().GetResultado().ToString() + ". Pulsa Enter para continuar";
        Debug.Log(GameObject.Find("Main").GetComponent<Metodos>().GetResultado().ToString());  // Escribir el resultado en la consola de Debug

        GetComponents<AudioSource>()[6].Play();  // Poner clip de exponente correcto

        // Movimiento de la boca de Rob
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[0];
        yield return new WaitForSeconds(0.15f);
        GameObject.Find("Rob").GetComponent<Image>().sprite = ImagenesRob[1];
        yield return new WaitForSeconds(0.5f);

        // PERMITIR CAMBIO DE ESCENA
        is_exponente = false; // Ya se ha introducido el exponente
        next_scene = true; // Ahora se permite el cambio de escena

        // HABILITAR PULSAR ENTER
        can_press_enter = true; // Permitir pulsar Enter

    }

    // RUTINA PARA PASAR A LA SIGUIENTE ESCENA
    private IEnumerator SiguienteEscena()
    {

        // Desaparición de la escena (fading)
        pantalla.GetComponent<RawImage>().CrossFadeAlpha(1.0f, 2.0f, false);

        yield return new WaitForSeconds(2.1f);  // Esperar al fading para cambiar de escena

        // Cambio de escena automático
        SceneManager.LoadScene("02 Mes");

    }

}

/*----------------------------------------------------------------------------------------------------------------------------------------------------------*/
