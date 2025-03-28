using System.Collections.Generic;
using Services.Data;
using UnityEngine;

namespace Services.Services
{
    public class DataService
    {
        public int Level;

        public Dictionary<WindowType, WindowData> Windows = new();
        public Dictionary<string, List<RewardStruct>> Rewards = new();
        public Dictionary<IconType, Sprite> Icons = new();

        public DataService()
        {
            Level = 1;
            
            LoadWindows();
            LoadRewards();
            LoadIcons();
        }
        
        private void LoadWindows()
        {
            var data = Resources.Load<AllWindowsData>("Configs/AllWindowData");
            foreach (var window in data.Windows)
            {
                Windows.Add(window.Type, window);
            }
        }
        
        private void LoadIcons()
        {
            var data = Resources.Load<IconsData>("Configs/IconsData");
            foreach (var icons in data.Icons)
            {
                Icons.Add(icons.Type, icons.Icon);
            }
        }
        
        private void LoadRewards()
        {
            var data = Resources.LoadAll<RewardData>("Configs/Rewards");
            foreach (var reward in data)
            {
                Rewards.Add(reward.ID, reward.RewardsList);
            }
        }
    }
}