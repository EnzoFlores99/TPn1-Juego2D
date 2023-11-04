using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class mainPanel : MonoBehaviour
{
   [Header ("Options")]
   public Slider FxVolume;
   public Slider volume;
   public Toggle mute;
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
      FxVolume.onValueChanged.AddListener(ChangeVolumeFx);
      volume.onValueChanged.AddListener(ChangeVolumeMaster);
   }
   public void PlayLevel(string levelName)
   {
      SceneManager.LoadScene(levelName);
   }
   public void SetMute()
   {
       
       if (mute.isOn)
       {
         mixer.GetFloat("VolMaster",out lastVol);
          mixer.SetFloat("VolMaster",-40);
       }
      else 
      {
         mixer.SetFloat("VolMaster",lastVol);
      }
        
   }

   public void OpenPanel(GameObject panel)
   {
    PanelMain.SetActive(false);
    OptionsPanel.SetActive(false);
    SelectLevelPanel.SetActive(false);

    panel.SetActive(true);
    PlaySoundButton();
   }

   public void ChangeVolumeMaster(float v)
   {
      mixer.SetFloat("VolMaster",v);
   }
   public void ChangeVolumeFx(float v)
   {
      mixer.SetFloat("VolFx",v);
   }
   public void PlaySoundButton()
   {
      FxSource.PlayOneShot(clickSound);
   }
}
