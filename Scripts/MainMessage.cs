using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMessage : BasePanel
{
    //    private CanvasGroup canvasgroup;
    public override void OnPause()
    {
        
    }

    public override void OnResume()
    {
        //    canvasGroup.blocksRaycasts = false;//当有菜单弹出时，菜单不与鼠标交互
    }
    public void OnPushPanel(string paneltypestring)
    {
        UiPaneltype paneltype = (UiPaneltype)System.Enum.Parse(typeof(UiPaneltype), paneltypestring);
        UIManager.Instance.pushPanel(paneltype);
    }
}
