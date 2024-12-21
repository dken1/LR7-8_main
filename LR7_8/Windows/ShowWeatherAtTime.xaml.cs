using LR7_8.Classes;
using LR7_8.DataModel;
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
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using LR7_8.CustomControls;

namespace LR7_8.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowWeatherAtTime.xaml
    /// </summary>
    public partial class ShowWeatherAtTime : Window
    {
        private Prognosis prognosis;
        public ShowWeatherAtTime(Prognosis prog)
        {
            InitializeComponent();
            prognosis = prog;
            labelContent.Content += " " + prognosis.Date.Value.ToShortDateString();
            LoadDataWrapPanel(prog.Time);
        }
        private void LoadDataWrapPanel(string info)
        {
            List<ComplexWeatherInfo> infos;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ComplexWeatherInfo>));
            using (StringReader reader = new StringReader(info))
            {
                infos = xmlSerializer.Deserialize(reader) as List<ComplexWeatherInfo>;
            }
            infos.ForEach(item => { wrapPanelWeather.Children.Add(new WeatherCustom(item)); });
        }
    }
}
