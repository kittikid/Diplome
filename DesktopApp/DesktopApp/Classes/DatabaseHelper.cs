using DesktopApp.Base;
using DesktopApp.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace DesktopApp
{
    public class DatabaseHelper
    {
        public List<TileData> GetItems() 
        {
            var items = new List<TileData>();
            var Database = SourceCore.RegProjectDatabase.RegProjectTable;
            Database.ToList().ForEach(rpt =>
            {
                items.Add(new TileData
                {
                    Metaid = $"{rpt.metaid}",
                    RegProjectName = rpt.fullname,
                    Code = rpt.code,
                    FederalProject = rpt.shortname,
                    Curator = rpt.curator,
                    Admin = rpt.person,
                    Supervisor = rpt.kvsr
                });
            });
            return items;
        }

        public List<TileData> LoadFirstPanel(long Metaid)
        {
            var items = new List<TileData>();
            var Database = SourceCore.RegProjectDatabase.RegProjectTable;

            items.Add(new TileData
            {
                Metaid = $"{Metaid}",
                RegProjectName = Database.First(x => x.metaid == Metaid).fullname,
                Code = Database.First(x => x.metaid == Metaid).code,
                FederalProject = Database.First(x => x.metaid == Metaid).shortname,
                Curator = Database.First(x => x.metaid == Metaid).curator,
                Admin = Database.First(x => x.metaid == Metaid).person,
                Supervisor = Database.First(x => x.metaid == Metaid).kvsr
            });
            return items;
        }

        public List<PurposesClass> GetPurposes(long Metaid)
        {
            var items = new List<PurposesClass>();
            var Database = SourceCore.RegProjectDatabase.purposes;
            Database.Where(x => x.metaid_rp == Metaid).ToList().ForEach(rpt =>
            {
                items.Add(new PurposesClass
                {
                    Metaid = $"{rpt.metaid}",
                    Taskname = rpt.taskname,
                    Code = $"{rpt.code}",
                    Description = rpt.description,
                    Typemrk = rpt.typemrk,
                    Typevaluemrk = rpt.typevaluemrk,
                    Okeicode = $"{rpt.okeicode}",
                    Okeiname = rpt.okeiname,
                    Basicvalueind = $"{rpt.basicvalueind}",
                    Value2018 = $"{rpt.value2018}",
                    Value2019 = $"{rpt.value2019}",
                    Value2020 = $"{rpt.value2020}",
                    Value2021 = $"{rpt.value2021}",
                    Value2022 = $"{rpt.value2022}",
                    Value2023 = $"{rpt.value2023}",
                    Value2024 = $"{rpt.value2024}",
                    Value2025 = $"{rpt.value2025}",
                    Value2026 = $"{rpt.value2026}",
                    Value2027 = $"{rpt.value2027}",
                    Value2028 = $"{rpt.value2028}",
                    Value2029 = $"{rpt.value2029}",
                    Value2030 = $"{rpt.value2030}",
                    Dockind = rpt.dockind,
                    Approgv = rpt.approgv,
                    Approvtdatenpa = rpt.approvtdatenpa,
                    Numbernpa = rpt.numbernpa,
                    Namenpa = rpt.namenpa,
                    Sourcedata = rpt.sourcedata,
                    Fpmrkid = rpt.fpmrkid,
                    Fpmrkname = rpt.fpmrkname,
                    Tasksrecordid = $"{rpt.tasksrecordid}",
                    Taskcode = $"{rpt.taskcode}",
                    Taskrespexec = rpt.taskrespexec,
                    Targettype = rpt.targettype,
                    Ozrname = rpt.ozrname,
                    Ozrnum = rpt.ozrnum,
                    Ozrbeneficiar = rpt.ozrbeneficiar,
                    Ozrokeicode = rpt.ozrokeicode,
                    Ozrokeiname = rpt.ozrokeiname,
                    Ozrtype = rpt.ozrtype,
                    Yearend = $"{rpt.yearend}",
                    Establishact = $"{rpt.establishact}",
                    Lvlmrk = $"{rpt.lvlmrk}",
                    Purposemonthdistribution = $"{rpt.purposemonthdistribution}"
                });
            });
            return items;
        }

        public List<TasksClass> GetTasks(long Metaid)
        {
            var items = new List<TasksClass>();
            var Database = SourceCore.RegProjectDatabase.tasks;
            Database.Where(x => x.metaid_rp == Metaid).ToList().ForEach(rpt =>
            {
                items.Add(new TasksClass
                {
                    Metaid = $"{rpt.metaid}",
                    Recordid = $"{rpt.recordid}",
                    Name = rpt.name,
                    Code = $"{rpt.code}",
                    Nprecordid = rpt.nprecordid,
                    Targettype = rpt.targettype,
                    Ozrrecordid = rpt.ozrrecordid,
                    Ozrname = rpt.ozrname,
                    Ozrnum = rpt.ozrnum,
                    Ozrbeneficiar = rpt.ozrbeneficiar,
                    Ozrokeicode = rpt.ozrokeicode,
                    Ozrokeiname = rpt.ozrokeiname,
                    Ozrtype = rpt.ozrtype,
                    Result = $"{rpt.result}"
                });
            });
            return items;
        }

        public List<ResultsClass> GetResults(long Metaid)
        {
            var items = new List<ResultsClass>();
            var Database = SourceCore.RegProjectDatabase.results;
            Database.Where(x => x.metaid_task == Metaid).ToList().ForEach(rpt =>
            {
                items.Add(new ResultsClass
                {
                    Metaid = $"{rpt.metaid}",
                    Name = rpt.name,
                    Code = $"{rpt.code}",   
                    Respexec = rpt.respexec,
                    Numbercharact = rpt.numbercharact
                });
            });
            return items;
        }

        public List<FinSuppClass> GetFinSupp(long Metaid)
        {
            var items = new List<FinSuppClass>();
            var Database = SourceCore.RegProjectDatabase.finsupportsall;
            Database.Where(x => x.metaid_rp == Metaid).ToList().ForEach(rpt =>
            {
                items.Add(new FinSuppClass
                {
                    Id = $"{rpt.id}",
                    Finsource = rpt.finsource,
                    Fo2019 = $"{rpt.fo2019}",
                    Fo2020 = $"{rpt.fo2020}",
                    Fo2021 = $"{rpt.fo2021}",
                    Fo2022 = $"{rpt.fo2022}",
                    Fo2023 = $"{rpt.fo2023}",
                    Fo2024 = $"{rpt.fo2024}",
                    Finsourcecode = rpt.finsourcecode
                });
            });
            return items;
        }
    }

}
