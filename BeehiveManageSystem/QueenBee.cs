using System;
using System.Windows.Controls;
using BeehiveManageSystem.Workers;
using System.Diagnostics;

namespace BeehiveManageSystem
{
    internal class QueenBee : Bee
    {
        /*-------- 常數 --------*/
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5F;
        private const float EGGS_PER_SHIFT = 0.45F;

        /*---- 屬性&支援欄位 ----*/
        public string StatusReport { get; private set; }
        public override float CostPerShift { get { return 2.15F; } }
        private float eggs = 0;
        private float unassignedWorkers = 3;
        private Bee[] workers = new Bee[0];

        /*------- 建構式 -------*/
        public QueenBee() : base("蜂后")
        {
            AssignBee("採蜜");
            AssignBee("製蜜");
            AssignBee("顧卵");
        }

        /*-------- 方法 --------*/

        private void UpdateStatusReport()
        {
            string VaultReport = $"－蜂蜜庫報告－\n{HoneyVault.StatusReport}\n";
            string eggReport = $"－蜂后報告－\n目前蜂卵：{eggs:0.0}顆\n";
            string unassignedReport = $"可指派工蜂：{Math.Floor(unassignedWorkers)}隻\n";
            string collectorStatus = $"採蜜工蜂：{WorkerStatus("採蜜")}\n";
            string manufacturerStatus = $"製蜜工蜂：{WorkerStatus("製蜜")}\n";
            string eggCareStatus = $"顧卵工蜂：{WorkerStatus("顧卵")}\n";
            string daysPassed = $"\n經過天數：{MainWindow.DaysPassed}";

            StatusReport = VaultReport + eggReport + unassignedReport +
                collectorStatus + manufacturerStatus + eggCareStatus + daysPassed;
        }
        private string WorkerStatus(string job)
        {
            int collector = 0, manufacturer = 0, eggCare = 0;
            foreach (Bee worker in workers)
            {
                switch (worker.Job)
                {
                    case "採蜜":
                        collector++;    break;                        
                    case "製蜜":
                        manufacturer++; break;                        
                    case "顧卵":
                        eggCare++;      break;                        
                    default:            break;                        
                }
            }
            switch (job)
            {
                case "採蜜":
                    return $"{collector}隻";
                case "製蜜":
                    return $"{manufacturer}隻";
                case "顧卵":
                    return $"{eggCare}隻";
                default:
                    return "發生錯誤。";
            }
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "採蜜":
                    AddWorker(new Collector());break;
                case "製蜜":
                    AddWorker(new Manufacturer());break;
                case "顧卵":
                    AddWorker(new EggCare(this));break;
                default:break;
            }
            UpdateStatusReport();
        }
        /// <summary>
        /// 擴充 workers 陣列 1 單位，並加入一個 Bee 參考。
        /// </summary>
        /// <param name="worker">要加入陣列的工蜂。</param>
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        protected override void DoJob()
        {
            // 執行 QueenBee 的工作
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
                worker.WorkNextShift();

            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
        }
    }
}