using System;
using System.Collections.Generic;
using System.Text;

namespace BeehiveManageSystem.Workers
{
    class Manufacturer : Bee
    {
        /*-------- 常數 --------*/
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15F;

        /*---- 屬性&支援欄位 ----*/
        public override float CostPerShift { get { return 1.7F; } }

        /*------- 建構式 -------*/
        public Manufacturer() : base("製蜜") { }

        /*-------- 方法 --------*/
        protected override void DoJob()
        {
            // 執行 Manufacturer 的工作
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }

    }
}