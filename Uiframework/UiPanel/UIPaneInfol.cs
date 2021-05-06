using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class UIPaneInfol:ISerializationCallbackReceiver
{[NonSerialized]
    public UiPaneltype panelType;
    public string panelTypeString;
    //{
    //    get
    //    {
    //        return panelType.ToString();
    //    }
    //    set
    //    {
    //        Debug.Log(value);
    //        UiPaneltype type = (UiPaneltype)System.Enum.Parse(typeof(UiPaneltype), value);
    //        panelType = type;
    //    }

    //}


    public string path;
    //反序列化
    public void OnAfterDeserialize()
    {
        Debug.Log(panelTypeString);
        UiPaneltype type = (UiPaneltype)System.Enum.Parse(typeof(UiPaneltype), panelTypeString);
               panelType = type;
    }

    public void OnBeforeSerialize()
    {
        throw new NotImplementedException();
    }
}
