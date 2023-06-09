using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    public class JsonClass
    {
        public class Datnum
        {
            public string metaid { get; set; }
            public string recordid { get; set; }
            public string code { get; set; }
            public string fullname { get; set; }
            public string shortname { get; set; }
            public string idfp { get; set; }
            public string fpcode { get; set; }
            public string fpname { get; set; }
            public string curator { get; set; }
            public string person { get; set; }
            public string kvsr { get; set; }
            public string recordupdate { get; set; }
            public string actualversion { get; set; }
            public Subject subject { get; set; }
            public Roiv roiv { get; set; }
            public List<Purpose> purposes { get; set; }
            public List<Task> tasks { get; set; }
            public List<Participant> participants { get; set; }
            public List<Finsupportsall> finsupportsall { get; set; }
        }

        public class Finsupportsall
        {
            public string fo2019 { get; set; }
            public string fo2020 { get; set; }
            public string fo2021 { get; set; }
            public string fo2022 { get; set; }
            public string fo2023 { get; set; }
            public string fo2024 { get; set; }
            public string finsource { get; set; }
            public string fo_total { get; set; }
            public string finsourcecode { get; set; }
            public int metaid_rp { get; set; }
        }

        public class Participant
        {
            public string metaid { get; set; }
            public string recordid { get; set; }
            public string fio { get; set; }
            public string headpost { get; set; }
            public string immsupervisor { get; set; }
            public string percemploy { get; set; }
            public string roleinproj { get; set; }
            public string codereestr { get; set; }
            public int metaid_rp { get; set; }
        }

        public class Purpose
        {
            public string metaid { get; set; }
            public string recordid { get; set; }
            public string mrkname { get; set; }
            public string code { get; set; }
            public string description { get; set; }
            public string typemrk { get; set; }
            public string typevaluemrk { get; set; }
            public string okeicode { get; set; }
            public string okeiname { get; set; }
            public string basicvalueind { get; set; }
            public string value2018 { get; set; }
            public string value2019 { get; set; }
            public string value2020 { get; set; }
            public string value2021 { get; set; }
            public string value2022 { get; set; }
            public string value2023 { get; set; }
            public string value2024 { get; set; }
            public string value2025 { get; set; }
            public string value2026 { get; set; }
            public string value2027 { get; set; }
            public string value2028 { get; set; }
            public string value2029 { get; set; }
            public string value2030 { get; set; }
            public string dockind { get; set; }
            public string approgv { get; set; }
            public string approvtdatenpa { get; set; }
            public string numbernpa { get; set; }
            public string namenpa { get; set; }
            public string sourcedata { get; set; }
            public string fpmrkid { get; set; }
            public string fpmrkname { get; set; }
            public string tasksrecordid { get; set; }
            public string taskcode { get; set; }
            public string taskname { get; set; }
            public string taskrespexec { get; set; }
            public string targettype { get; set; }
            public string ozrname { get; set; }
            public string ozrnum { get; set; }
            public string ozrbeneficiar { get; set; }
            public string ozrokeicode { get; set; }
            public string ozrokeiname { get; set; }
            public string ozrtype { get; set; }
            public string yearend { get; set; }
            public string establishact { get; set; }
            public string lvlmrk { get; set; }
            public List<Purposemonthdistribution> purposemonthdistribution { get; set; }
            public int metaid_rp { get; set; }
        }

        public class Purposemonthdistribution
        {
            public string year { get; set; }
            public string mrk02 { get; set; }
            public string mrk03 { get; set; }
            public string mrk04 { get; set; }
            public string mrk05 { get; set; }
            public string mrk06 { get; set; }
            public string mrk07 { get; set; }
            public string mrk08 { get; set; }
            public string mrk09 { get; set; }
            public string mrk10 { get; set; }
            public string mrk11 { get; set; }
            public string mrk12 { get; set; }
            public string mrkendyaer { get; set; }
            public string reasonsmo { get; set; }
            public string recordid { get; set; }
            public int metaid_purposes {get; set; } 
        }

        public class Result
        {
            public string metaid { get; set; }
            public string recordid { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string basicvalue { get; set; }
            public string monetary_result { get; set; }
            public string fpresult { get; set; }
            public string respexec { get; set; }
            public string orgrespexec { get; set; }
            public string numbercharact { get; set; }
            public string typeres { get; set; }
            public string kindres { get; set; }
            public string realizemo { get; set; }
            public string notsubjfund { get; set; }
            public string subjfund { get; set; }
            public string iskey { get; set; }
            public string okeicode { get; set; }
            public string okeiname { get; set; }
            public string sourcedata { get; set; }
            public string cumulative { get; set; }
            public string cbaccumulationtype { get; set; }
            public string typevaluemrk { get; set; }
            public string costwaycode { get; set; }
            public string directionexpenses { get; set; }
            public string direxpcoderesf { get; set; }
            public string direxpnameresf { get; set; }
            public string executpost { get; set; }
            public List<object> resultorderlink { get; set; }
            public List<object> resotherproj { get; set; }
            public int metaid_task { get; set; }
        }

        public class Roiv
        {
            public string recordid { get; set; }
            public string name { get; set; }
        }

        public class Root
        {
            public int offset { get; set; }
            public int pageNum { get; set; }
            public int pageSize { get; set; }
            public int recordCount { get; set; }
            public List<Datnum> data { get; set; }
            public string order { get; set; }
            public string orderDirection { get; set; }
            public string version { get; set; }
            public int pageCount { get; set; }
        }

        public class Subject
        {
            public string recordid { get; set; }
            public string code { get; set; }
            public string name { get; set; }
        }

        public class Task
        {
            public string metaid { get; set; }
            public string recordid { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string nprecordid { get; set; }
            public string targettype { get; set; }
            public string ozrrecordid { get; set; }
            public string ozrname { get; set; }
            public string ozrnum { get; set; }
            public string ozrbeneficiar { get; set; }
            public string ozrokeicode { get; set; }
            public string ozrokeiname { get; set; }
            public string ozrtype { get; set; }
            public List<Result> results { get; set; }
            public int metaid_rp { get; set; }
        }
    }
}
