using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WR_file_sorting_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var resultStr = new StringBuilder();
                var invlaidStr = new StringBuilder();
                var careVisits = CSVHelper.GetCsvListFromFile("sample.csv").OrderBy(X => X.ClientId).ThenBy(Y => Y.Start);

                int lastClientID = -1;
                DateTime lastEndDate = new DateTime();
                foreach(var visit in careVisits)
                {
                    if (!visit.InvalidTimes)
                    {
                        if (visit.ClientId == lastClientID)
                        {
                            if (lastEndDate > visit.Start)
                            {
                                var diff = visit.End.Subtract(visit.Start);
                                visit.Start = lastEndDate;
                                visit.End = lastEndDate.Add(diff);
                            }                           
                        }                   
                        resultStr.AppendFormat("{0},{1},{2},{3},{4}{5}", visit.Id, visit.ClientId, visit.Start, visit.End, visit.ClientName, Environment.NewLine);
                        lastEndDate = visit.End;
                        lastClientID = visit.ClientId;
                    }
                    else
                    {
                        invlaidStr.AppendFormat("{0},{1},{2},{3},{4}{5}", visit.Id, visit.ClientId, visit.StartString, visit.EndString, visit.ClientName, Environment.NewLine);
                    }
                }

                CSVHelper.WriteCsvFile("result.csv", resultStr.ToString());
                CSVHelper.WriteCsvFile("invalid.csv", invlaidStr.ToString());

                lblResult.Content = "Sorted";
            }
            catch(Exception ex)
            {
                lblResult.Content = ex.Message;
            }           
        }


    }
}
