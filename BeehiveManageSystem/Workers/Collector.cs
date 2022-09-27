using System;
using System.Collections.Generic;
using System.Text;

namespace BeehiveManageSystem.Workers
{
    class Collector : Bee
    {
        /*-------- 常數 --------*/
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25F;

        /*---- 屬性&支援欄位 ----*/
        public override float CostPerShift { get { return 1.95F; } }

        /*------- 建構式 -------*/
        public Collector() : base("採蜜") { }

        /*-------- 方法 --------*/
        protected override void DoJob()
        {
            // 執行 Collector 的工作
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
