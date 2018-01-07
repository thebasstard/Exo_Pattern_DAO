using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_DAO1
{
    public class Employe
    {
        private string matricule;
        private string nom;
        private string prenom;
        private double salaire;//private float salaire;
        private double commission;//private float commission
        private int num_Dept;

        public string Matricule
        {
            get { return matricule; }
            set { matricule = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public double Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        public double Commission
        {
            get { return commission; }
            set { commission = value; }
        }

        public int Num_Dept
        {
            get { return num_Dept; }
            set { num_Dept = value; }
        }
      
        public Employe() { }

        public Employe(string Matri, string No, string Preno,float Sal,float Com,int Num_D)
        {
            matricule = Matri;
            nom = No;
            prenom = Preno;
            salaire = Sal;
            commission = Com;
            num_Dept = Num_D;
        }

        public override string ToString()
        {
            return "Matricule : " + matricule + ", Nom : " + nom + ", Prenom : " + prenom + ", Salaire : " 
                    + salaire + ", Comission : " + commission + ", Numéro de département : " + num_Dept;
        }
    }
}
