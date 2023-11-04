using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainPanel : MonoBehaviour
{
   [Header ("Options")]
   public Slider FxVolume;
   public Slider volume;
   public Toggle mute;
   [Header("panels")]
   public GameObject PanelMain;
   public GameObject OptionsPanel;
   public GameObject SelectLevelPanel;


   public void OpenPanel(GameObject panel)
   {
    PanelMain.SetActive(false);
    OptionsPanel.SetActive(false);
    SelectLevelPanel.SetActive(false);

    panel.SetActive(true);
   }
}
