using System.Collections.Generic;
using UnityEngine;

namespace Services.Data
{
    [CreateAssetMenu(fileName = "RewardData", menuName = "Data/RewardData")]
    public class RewardData : ScriptableObject
    {
        public string ID;
        public List<RewardStruct> RewardsList;
    }
}