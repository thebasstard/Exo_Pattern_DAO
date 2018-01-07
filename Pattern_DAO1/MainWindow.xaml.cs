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

namespace Pattern_DAO1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            InitializeComponent();

            List<string> ListeEmp = new List<string>();

            EmployeDAO EmpDAO = new EmployeDAO();

            ListeEmp = EmpDAO.ListeEmploye();

            foreach (string ee in ListeEmp)
            {
                listView.Items.Add(ee);
            }

        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            Employe Emplo1 = new Employe();

            Emplo1.Nom = textBoxNom.Text;
            Emplo1.Prenom = "un prenom";
            Emplo1.Matricule = "un n";
            Emplo1.Salaire = 1500;
            Emplo1.Commission = 700;

            EmployeDAO EmploDAO1 = new EmployeDAO();

            EmploDAO1.InsertEmploye(Emplo1);
        }

        private void buttonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Employe EmpSupp1 = new Employe();
            EmployeDAO Em1 = new EmployeDAO();

            EmpSupp1.Matricule = textBoxMatricule.Text;
            Em1.DeleteEmploye(EmpSupp1);
        }

        private void buttonModifier_Click(object sender, RoutedEventArgs e)
        {
            Employe e1 = new Employe();
            EmployeDAO em1 = new EmployeDAO();

            e1.Matricule = textBoxMatricule.Text;
            e1.Nom = textBoxNom.Text;
            e1.Prenom = "Tigre";
            e1.Salaire = 500000;
            e1.Commission = 700;

            em1.UpdateEmploye(e1);
        }

        private void buttonTrouver_Click(object sender, RoutedEventArgs e)
        {
            Employe eT = new Employe();
            EmployeDAO eTDAO = new EmployeDAO();

            eT = eTDAO.Trouver(textBoxMatricule.Text);
            textBoxNom.Text = eT.Nom;
        }

        private void buttonTrier_Click(object sender, RoutedEventArgs e)
        {
            listBoxDuF.Items.Clear();

            EmployeDAO TriComission = new EmployeDAO();
            Employe e4 = new Employe();
            List<string> ls = new List<string>();

            ls = TriComission.ListeParService(Convert.ToDouble(textBoxCom.Text));

            foreach (string item in ls)
            {
                listBoxDuF.Items.Add(item);
            }

        }

        private void buttonXml_Click(object sender, RoutedEventArgs e)
        {
            EmployeDAO Edao = new EmployeDAO();
            Edao.ListeObjet();
        }

    }
}

