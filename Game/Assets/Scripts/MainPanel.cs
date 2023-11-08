using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class mainPanel : MonoBehaviour
{
   [Header ("Options")]
   //slider que usamos para el volumen de efectos
   public Slider FxVolume;
   //slider para el volumen general
   public Slider volume;
   //marcador para silenciar los sonidos
   public Toggle mute;
   //referencia al componenete que usaremos para la reproduccion
   public AudioMixer mixer;
   [Header("panels")]
   
   public GameObject PanelMain;
   public GameObject OptionsPanel;
   public GameObject SelectLevelPanel;
   public AudioSource FxSource;
   public AudioClip clickSound;
   private float lastVol;

   public void Awake()
   {
      //cuando cambie el valor del slider de volumen de efectos llame a la funcion
      FxVolume.onValueChanged.AddListener(ChangeVolumeFx);
      //cuando cambie el valor del slider de volumen llame a la funcion
      volume.onValueChanged.AddListener(ChangeVolumeMaster);
   }
   public void PlayLevel(string levelName)
   {//de acuerdo al boton orpimido, inicia la escena solicitada
      SceneManager.LoadScene(levelName);
   }
   public void SetMute()
   {
       
       if (mute.isOn)
       {
         //recupera el ultimo valor del volumen general
         mixer.GetFloat("VolMaster",out lastVol);
         //se le asigna el valor de - al volumen general
          mixer.SetFloat("VolMaster",-40);
       }
      else  
      {//se le asigna el ultimo valor al volumen
         mixer.SetFloat("VolMaster",lastVol);
      }
        
   }

   public void OpenPanel(GameObject panel)
   {//desactivamos los paneles
    PanelMain.SetActive(false);
    OptionsPanel.SetActive(false);
    SelectLevelPanel.SetActive(false);
   //activamos el panel que estamos pasando como parametro
    panel.SetActive(true);
    PlaySoundButton();
   }

   //metodo para cambiar el volumen general
   public void ChangeVolumeMaster(float v)
   {
      //establece el valor del parametro
      mixer.SetFloat("VolMaster",v);
   }
   //metodo para cambiar el volumen de efectos
   public void ChangeVolumeFx(float v)
   {
      //establece el valor del parametro
      mixer.SetFloat("VolFx",v);
   }
   //metodo para reproducir el sonido del boton
   public void PlaySoundButton()
   {
      FxSource.PlayOneShot(clickSound);
   }
}
