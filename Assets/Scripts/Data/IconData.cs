using System;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Data
{
    [Serializable]
    public struct IconStruct 
    {
        public IconType Type;
        public Sprite Icon;
    }
}