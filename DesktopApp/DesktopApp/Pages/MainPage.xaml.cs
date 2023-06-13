using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Net;
using Newtonsoft.Json;
using static DesktopApp.JsonClass;
using DesktopApp.Base;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Data.Entity;
using DesktopApp.Windows;
using DesktopApp.Classes;

namespace DesktopApp.Pages
{
    public class ViewModel
    {
        public List<TileData> Items { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private DatabaseHelper databaseHelper;
        public MainPage(List<UserLogin> user)
        {
            InitializeComponent();

            databaseHelper = new DatabaseHelper();
            _user = user;
            items = databaseHelper.GetItems();

            SetPage(currentPage);
            CheckUserRole();
        }

        private List<UserLogin> _user;
        private List<TileData> items;
        private int currentPage = 0;
        private int itemsPerPage = 5;

        private void CheckUserRole()
        {
            if (_user == null) return;

            foreach (var rpt in _user)
            {
                RegUsers.Visibility = Visibility.Collapsed;
                if (rpt.Role == 1)
                {
                    RegUsers.Visibility = Visibility.Visible;
                }
            }
        }

        //-------------------пагинация-----------------
        private void SetPage(int page)
        {
            currentPage = page;
            PageNumber.Text = $"{currentPage + 1}";

            List<TileData> tileDatas = items.Select(x => x).Skip(currentPage * itemsPerPage).Take(itemsPerPage).ToList();
            DataContext = new ViewModel { Items = tileDatas };
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 0)
            {
                SetPage(currentPage - 1);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage < (items.Count / itemsPerPage) - 1)
            {
                SetPage(currentPage + 1);
            }
        }

        private void itemsPerPage_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemsPerPage = Int32.Parse(tbItemsPerPage.Text);
        }

        //-------------------навигация-----------------
        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var regProjectItem = ((FrameworkElement)sender).DataContext as TileData; //коллекция элементов 
            if (regProjectItem != null)
            {
                this.NavigationService.Navigate(new MoreInfoPage(regProjectItem.Metaid, _user));
                //MainPageFrame.Navigate(new MoreInfoPage(regProjectItem.Metaid));
            }
        }

        //-------------------выделение текста-----------------
        private void tbRegProject_MouseEnter(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(77, 112, 145));
            focusTextBlock.TextDecorations = TextDecorations.Underline;
        }

        private void tbRegProject_MouseLeave(object sender, MouseEventArgs e)
        {
            var focusTextBlock = (TextBlock)sender;
            focusTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(98, 141, 183));
            focusTextBlock.TextDecorations = null;
        }

        //-------------------основной процесс-----------------
        private void UploadNow_Click(object sender, RoutedEventArgs e)
        {
            UrlParse();
        }

        private void UrlParse()
        {
            //3 переменных для ссылки
            string url = "https://budget.gov.ru/epbs/registry/7710168360-REGIONALPROJECT/data";
            Root jsonObject = JsonConvert.DeserializeObject<Root>(new WebClient().DownloadString(url));
            //---1---
            RoivUpload(jsonObject);
            SubjectUpload(jsonObject);
            //---2---
            RegProjectUpload(jsonObject);
            //---3---
            PurposeUpload(jsonObject);
            FinsupportsallUpload(jsonObject);
            ParticipantUpload(jsonObject);
            TaskUpload(jsonObject);
            //---4---
            PurposemonthdistributionUpload(jsonObject);
            ResultUpload(jsonObject);
        }

        private void RoivUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var roiv = root.data[i].roiv;
                var data = new roiv
                {
                    recordid = Int64.Parse(roiv.recordid),
                    name = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(roiv.name))
                };
                SourceCore.RegProjectDatabase.roiv.Add(data);
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }

        }

        private void SubjectUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var subject = root.data[i].subject;
                var data = new subject
                {
                    recordid = Int32.Parse(subject.recordid),
                    code = Int32.Parse(subject.code),
                    name = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(subject.name))
                };
                SourceCore.RegProjectDatabase.subject.Add(data);
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private void RegProjectUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var regProject = root.data[i];
                var data = new RegProjectTable
                {
                    metaid = Int64.Parse(regProject.metaid),
                    recordid = Int64.Parse(regProject.recordid),
                    code = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.code)),
                    fullname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.fullname)),
                    shortname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.shortname)),
                    idfp = short.Parse(root.data[i].idfp),
                    fpcode = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.fpcode)),
                    fpname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.fpname)),
                    curator = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.curator)),
                    person = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.person)),
                    kvsr = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.kvsr)),
                    actualversion = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(regProject.actualversion)),
                    subject = Int32.Parse(regProject.subject.recordid),
                    roiv = Int64.Parse(regProject.roiv.recordid)
                };
                SourceCore.RegProjectDatabase.RegProjectTable.Add(data);
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private decimal DecimalPoint(string num)
        {
            return decimal.Parse(num, CultureInfo.InvariantCulture);
        }
        private void PurposeUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var dp = root.data[i];
                for (int j = 0; j < dp.purposes.Count; j++)
                {
                    var purpose = dp.purposes[j];
                    var data = new purposes
                    {
                        metaid = Int64.Parse(purpose.metaid),
                        recordid = Int64.Parse(purpose.recordid),
                        mrkname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.mrkname)),
                        code = Int32.Parse(purpose.code),
                        description = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.description)),
                        typemrk = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.typemrk)),
                        typevaluemrk = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.typevaluemrk)),
                        okeicode = Int32.Parse(purpose.okeicode),
                        okeiname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.okeiname)),
                        basicvalueind = DecimalPoint(purpose.basicvalueind),
                        value2018 = DecimalPoint(purpose.value2018),
                        value2019 = DecimalPoint(purpose.value2019),
                        value2020 = DecimalPoint(purpose.value2020),
                        value2021 = DecimalPoint(purpose.value2021),
                        value2022 = DecimalPoint(purpose.value2022),
                        value2023 = DecimalPoint(purpose.value2023),
                        value2024 = DecimalPoint(purpose.value2024),
                        value2025 = DecimalPoint(purpose.value2025),
                        value2026 = DecimalPoint(purpose.value2026),
                        value2027 = DecimalPoint(purpose.value2027),
                        value2028 = DecimalPoint(purpose.value2028),
                        value2029 = DecimalPoint(purpose.value2029),
                        value2030 = DecimalPoint(purpose.value2030),
                        dockind = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.dockind)),
                        approgv = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.approgv)),
                        approvtdatenpa = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.approvtdatenpa)),
                        numbernpa = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.numbernpa)),
                        namenpa = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.namenpa)),
                        sourcedata = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.sourcedata)),
                        fpmrkid = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.fpmrkid)),
                        fpmrkname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.fpmrkname)),
                        tasksrecordid = Int64.Parse(purpose.tasksrecordid),
                        taskcode = Int32.Parse(purpose.taskcode),
                        taskname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.taskname)),
                        taskrespexec = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.taskrespexec)),
                        targettype = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.targettype)),
                        ozrname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.ozrname)),
                        ozrnum = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.ozrnum)),
                        ozrbeneficiar = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.ozrbeneficiar)),
                        ozrokeicode = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.ozrokeicode)),
                        ozrokeiname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.ozrokeiname)),
                        ozrtype = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(purpose.ozrtype)),
                        yearend = Int32.Parse(purpose.yearend),
                        establishact = Int32.Parse(purpose.establishact),
                        lvlmrk = Int32.Parse(purpose.lvlmrk),
                        metaid_rp = Int64.Parse(dp.metaid)
                    };
                    SourceCore.RegProjectDatabase.purposes.Add(data);
                }
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private void PurposemonthdistributionUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var dp = root.data[i];
                for (int j = 0; j < dp.purposes.Count; j++)
                {
                    var purpose = dp.purposes[j];
                    for (int k = 0; k < purpose.purposemonthdistribution.Count; k++)
                    {
                        var prb = purpose.purposemonthdistribution[k];
                        var data = new purposemonthdistribution
                        {
                            year = short.Parse(prb.year),
                            mrk02 = DecimalPoint(prb.mrk02),
                            mrk03 = DecimalPoint(prb.mrk03),
                            mrk04 = DecimalPoint(prb.mrk04),
                            mrk05 = DecimalPoint(prb.mrk05),
                            mrk06 = DecimalPoint(prb.mrk06),
                            mrk07 = DecimalPoint(prb.mrk07),
                            mrk08 = DecimalPoint(prb.mrk08),
                            mrk09 = DecimalPoint(prb.mrk09),
                            mrk10 = DecimalPoint(prb.mrk10),
                            mrk11 = DecimalPoint(prb.mrk11),
                            mrk12 = DecimalPoint(prb.mrk12),
                            mrkendyaer = DecimalPoint(prb.mrkendyaer),
                            reasonsmo = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(prb.reasonsmo)),
                            recordid = Int64.Parse(prb.recordid),
                            metaid_purposes = Int64.Parse(purpose.metaid)
                        };
                        SourceCore.RegProjectDatabase.purposemonthdistribution.Add(data);
                    }
                }
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private void FinsupportsallUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var dp = root.data[i];
                for (int j = 0; j < dp.finsupportsall.Count; j++)
                {
                    var fs = dp.finsupportsall[j];
                    var data = new finsupportsall
                    {
                        fo2019 = DecimalPoint(fs.fo2019),
                        fo2020 = DecimalPoint(fs.fo2020),
                        fo2021 = DecimalPoint(fs.fo2021),
                        fo2022 = DecimalPoint(fs.fo2022),
                        fo2023 = DecimalPoint(fs.fo2023),
                        fo2024 = DecimalPoint(fs.fo2024),
                        finsource = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(fs.finsource)),
                        fo_total = DecimalPoint(fs.fo_total),
                        finsourcecode = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(fs.finsourcecode)),
                        metaid_rp = Int64.Parse(dp.metaid)
                    };
                    SourceCore.RegProjectDatabase.finsupportsall.Add(data);
                }
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private void ParticipantUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var dp = root.data[i];
                for (int j = 0; j < dp.participants.Count; j++)
                {
                    var participant = dp.participants[j];
                    var data = new participants
                    {
                        metaid = Int64.Parse(participant.metaid),
                        recordid = Int64.Parse(participant.recordid),
                        fio = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(participant.fio)),
                        headpost = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(participant.headpost)),
                        immsupervisor = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(participant.immsupervisor)),
                        percemploy = Int32.Parse(participant.percemploy),
                        roleinproj = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(participant.roleinproj)),
                        codereestr = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(participant.codereestr)),
                        metaid_rp = Int64.Parse(dp.metaid)
                    };
                    SourceCore.RegProjectDatabase.participants.Add(data);
                }
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private void TaskUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var dp = root.data[i];
                for (int j = 0; j < dp.tasks.Count; j++)
                {
                    var task = dp.tasks[j];
                    var data = new tasks
                    {
                        metaid = Int64.Parse(task.metaid),
                        recordid = Int64.Parse(task.recordid),
                        name = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.name)),
                        code = Int32.Parse(task.code),
                        nprecordid = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.nprecordid)),
                        targettype = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.targettype)),
                        ozrrecordid = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.ozrrecordid)),
                        ozrname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.ozrname)),
                        ozrnum = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.ozrnum)),
                        ozrbeneficiar = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.ozrbeneficiar)),
                        ozrokeicode = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.ozrokeicode)),
                        ozrokeiname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.ozrokeiname)),
                        ozrtype = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(task.ozrtype)),
                        metaid_rp = Int64.Parse(dp.metaid)
                    };
                    SourceCore.RegProjectDatabase.tasks.Add(data);
                }
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private void ResultUpload(Root root)
        {
            for (int i = 0; i < root.data.Count; i++)
            {
                var dp = root.data[i];
                for (int j = 0; j < dp.tasks.Count; j++)
                {
                    var task = dp.tasks[j];
                    for (int k = 0; k < task.results.Count; k++)
                    {
                        var result = task.results[k];
                        var data = new results
                        {
                            metaid = Int64.Parse(result.metaid),
                            recordid = Int64.Parse(result.recordid),
                            code = Int32.Parse(result.code),
                            name = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.name)),
                            basicvalue = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.basicvalue)),
                            monetary_result = Int32.Parse(result.monetary_result),
                            fpresult = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.fpresult)),
                            respexec = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.respexec)),
                            orgrespexec = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.orgrespexec)),
                            numbercharact = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.numbercharact)),
                            typeres = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.typeres)),
                            kindres = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.kindres)),
                            realizemo = Int32.Parse(result.realizemo),
                            notsubjfund = Int32.Parse(result.notsubjfund),
                            subjfund = Int32.Parse(result.subjfund),
                            iskey = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.iskey)),
                            okeicode = short.Parse(result.okeicode),
                            okeiname = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.okeiname)),
                            sourcedata = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.sourcedata)),
                            cumulative = Int32.Parse(result.cumulative),
                            cbaccumulationtype = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.cbaccumulationtype)),
                            typevaluemrk = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.typevaluemrk)),
                            costwaycode = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.costwaycode)),
                            directionexpenses = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.directionexpenses)),
                            direxpcoderesf = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.direxpcoderesf)),
                            direxpnameresf = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.direxpnameresf)),
                            executpost = Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1251").GetBytes(result.executpost)),
                            metaid_task = Int64.Parse(task.metaid)
                        };
                        SourceCore.RegProjectDatabase.results.Add(data);
                    }
                }
            }
            try
            {
                try
                {
                    SourceCore.RegProjectDatabase.SaveChanges();
                }
                catch { }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }

        private void RegUsers_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }
    }
}
