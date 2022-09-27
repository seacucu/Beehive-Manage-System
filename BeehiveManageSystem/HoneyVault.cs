using System;
using System.Collections.Generic;
using System.Text;

namespace BeehiveManageSystem
{
    static class HoneyVault
    {
        /*-------- 常數 --------*/
        private const float CONVERSION_RATIO = 0.19f;
        private const float LOW_WARNING = 10f;

        /*---- 屬性&支援欄位 ----*/
        private static float nectar = 100f;
        private static float honey = 25f;
        public static string StatusReport 
        {
            get { 
                string massage = $"花蜜量：{nectar:0.0}\n蜂蜜量：{honey:0.0}\n";
                if (nectar < LOW_WARNING)
                    massage += "警告，花蜜量低，請加派工蜂採蜜！\n";
                if (honey < LOW_WARNING)
                    massage += "警告，蜂蜜量低，請加派工蜂製蜜！\n";
                return massage;
            }
        }

        /*-------- 方法 --------*/

        /// <summary>
        /// 讓蜜蜂收集amount量的花蜜，存入HoneyVault.nector。
        /// </summary>
        /// <param name="amount"></param>
        public static void CollectNectar(float amount)
        {
            if (amount > 0)
                nectar += amount;
        }

        /// <summary>
        /// 將amount量的花蜜按照CONVERSION_RATIO的比例轉為蜂蜜。
        /// </summary>
        /// <param name="amount"></param>
        public static void ConvertNectarToHoney(float amount)
        {
            if (amount > nectar) 
                amount = nectar;
            nectar -= amount;
            honey += amount * CONVERSION_RATIO;
        }

        /// <summary>
        /// 讓蜜蜂吃掉amount量的蜂蜜，並回傳是否足量（若不足量就不會吃）。
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount)
            {
                honey -= amount;
                return true;
            }
            return false;
        }
    }
}
