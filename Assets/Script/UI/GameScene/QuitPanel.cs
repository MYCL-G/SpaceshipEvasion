using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitPanel : BasePanel<QuitPanel>
{
    public Button btnQuit;
    public Button btnClose;
    public override void Init()
    {
        btnQuit.onClick.AddListener(()=>{
            SceneManager.LoadScene("BeginScene");
            Time.timeScale=1;
        });
        btnClose.onClick.AddListener(()=>{
            Hide();
            Time.timeScale=1;
        });
        Hide();
    }
}
