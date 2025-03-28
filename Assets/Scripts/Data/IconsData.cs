using System.Collections.Generic;
using UnityEngine;

namespace Services.Data
{
    [CreateAssetMenu(fileName = "IconsData", menuName = "Data/IconsData")]
    public class IconsData : ScriptableObject
    {
        public List<IconStruct> Icons;
    }
}