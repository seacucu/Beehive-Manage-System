using System;
using System.Collections.Generic;
using System.Text;

namespace BeehiveManageSystem
{
    class Bee
    {
        /*---- 屬性&支援欄位 ----*/
        public virtual float CostPerShift { get; }
        public string Job { get; private set; }

        /*------- 建構式 -------*/
        public Bee(string job) 
        { Job = job; }

        /*-------- 方法 --------*/
        public void WorkNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))  
                DoJob();        
        }

        protected virtual void DoJob()
        {
            // 讓子類別覆寫
        }
    }
}