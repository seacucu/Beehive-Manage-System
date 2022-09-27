using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BeehiveManageSystem.Workers
{
    class EggCare : Bee
    {
        /*-------- 常數 --------*/
        private const float CARE_PROGRESS_PER_SHIFT = 0.15F;        

        /*---- 屬性&支援欄位 ----*/
        public override float CostPerShift { get { return 1.35F; } }
        private QueenBee queen; //指向唯一蜂后的參考

        /*------- 建構式 -------*/
        public EggCare(QueenBee queen) : base("顧卵")
        {
            this.queen = queen;
        }

        /*-------- 方法 --------*/
        protected override void DoJob()
        {
            // 執行 Egg Care 的工作
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
