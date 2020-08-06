using DAN_LI_Dejan_Prodanovic.Model;
using DAN_LI_Dejan_Prodanovic.ViewModel;
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

namespace DAN_LI_Dejan_Prodanovic.View
{
    /// <summary>
    /// Interaction logic for PatientMainView.xaml
    /// </summary>
    public partial class PatientMainView : Window
    {
        public PatientMainView()
        {
            InitializeComponent();
            DataContext = new PatientMainViewModel(this);
        }
        public PatientMainView(tblPatient patient)
        {
            InitializeComponent();
            DataContext = new PatientMainViewModel(this, patient);
        }
    }
}
