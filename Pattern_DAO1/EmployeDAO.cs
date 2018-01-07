using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Xml.Serialization;//Pour utiliser la serialization
using System.IO;//pour utiliser StreamReader

namespace Pattern_DAO1
{
    class EmployeDAO
    {
        string Chaine_sql = "server=(local);database=Employes;integrated security=true";
        SqlConnection Connexion;

        public EmployeDAO()
        {
            Connexion = new SqlConnection(Chaine_sql);
        }

        public void InsertEmploye(Employe E)
        {
            Connexion.Open();

            SqlCommand RequeteInsert = new SqlCommand("insert into Emp(Matricule,Nom,Prenom,Salaire,Commission) values (@p1,@p2,@p3,@p4,@p5)", Connexion);
            RequeteInsert.Parameters.AddWithValue("@p1", E.Matricule);
            RequeteInsert.Parameters.AddWithValue("@p2", E.Nom);
            RequeteInsert.Parameters.AddWithValue("@p3", E.Prenom);
            RequeteInsert.Parameters.AddWithValue("@p4", E.Salaire);
            RequeteInsert.Parameters.AddWithValue("@p5", E.Commission);
            //RequeteInsert.Parameters.AddWithValue("@p6", E.Num_Dept);

            RequeteInsert.ExecuteNonQuery();

            Connexion.Close();
        }

        public void UpdateEmploye(Employe E)
        {
            Connexion.Open();

            SqlCommand RequeteUpdate = new SqlCommand("update Emp set Nom = @p1, Prenom = @p2, Salaire = @p3, Commission = @p4 where Matricule = @p6", Connexion);
            RequeteUpdate.Parameters.AddWithValue("@p1", E.Nom);
            RequeteUpdate.Parameters.AddWithValue("@p2", E.Prenom);
            RequeteUpdate.Parameters.AddWithValue("@p3", E.Salaire);
            RequeteUpdate.Parameters.AddWithValue("@p4", E.Commission);
            //RequeteUpdate.Parameters.AddWithValue("@p5", E.Num_Dept);
            RequeteUpdate.Parameters.AddWithValue("@p6", E.Matricule);

            RequeteUpdate.ExecuteNonQuery();

            Connexion.Close();
        }

        public void DeleteEmploye(Employe E)
        {
            Connexion.Open();

            SqlCommand RequeteDelete = new SqlCommand("delete from Emp where Matricule = @p1", Connexion);
            RequeteDelete.Parameters.AddWithValue("@p1", E.Matricule);

            RequeteDelete.ExecuteNonQuery();

            Connexion.Close();
        }

        public Employe Trouver(string matrifion)
        {
            Employe Em = new Employe();

            Connexion.Open();

            SqlCommand RequeteSelect = new SqlCommand("select Matricule, Nom, Prenom, Salaire, Commission from Emp where Matricule = @p1", Connexion);
            RequeteSelect.Parameters.AddWithValue("@p1", matrifion);
            SqlDataReader ResultatRequete = RequeteSelect.ExecuteReader();

            if (ResultatRequete.Read())
            {
                Em.Matricule = Convert.ToString(ResultatRequete["Matricule"]);
                Em.Nom = Convert.ToString(ResultatRequete["Nom"]);
                Em.Prenom = Convert.ToString(ResultatRequete["Prenom"]);
                Em.Salaire = Convert.ToDouble(ResultatRequete["Salaire"]);
                Em.Commission = Convert.ToDouble(ResultatRequete["Commission"]);
                //Em.Num_Dept = Convert.ToInt32(ResultatRequete["Num_Dept"]);
            }

            Connexion.Close();

            return Em;
        }

        public List<string> ListeEmploye()
        {
            List<string> ListeE = new List<string>();
            Employe Ep = new Employe();

            Connexion.Open();

            SqlCommand TousLesEmployes = new SqlCommand("select * from Emp", Connexion);
            SqlDataReader Resultat = TousLesEmployes.ExecuteReader();

            while (Resultat.Read())
            {
                Ep.Matricule = Convert.ToString(Resultat["Matricule"]);
                Ep.Nom = Convert.ToString(Resultat["Nom"]);
                Ep.Prenom = Convert.ToString(Resultat["Prenom"]);
                Ep.Salaire = Convert.ToDouble(Resultat["Salaire"]);
                Ep.Commission = Convert.ToDouble(Resultat["Commission"]);
                //Ep.Num_Dept = Convert.ToInt32(Resultat["Num_Dept"]);

                ListeE.Add(Ep.ToString());
                
            }

            Connexion.Close();

            return ListeE;

        }

        public List<string> ListeParService(double com)
        {
            List<string> listt = new List<string>();

            Employe e = new Employe();

            Connexion.Open();

            SqlCommand RequeteParCommission = new SqlCommand("select * from Emp where Commission = @p5", Connexion);
            RequeteParCommission.Parameters.AddWithValue("@p5", com);

            SqlDataReader LireData = RequeteParCommission.ExecuteReader();

            if (LireData.HasRows)
            {
                while (LireData.Read())
                {
                    e.Matricule = Convert.ToString(LireData["Matricule"]);
                    e.Nom = Convert.ToString(LireData["Nom"]);
                    e.Prenom = Convert.ToString(LireData["Prenom"]);
                    e.Salaire = Convert.ToDouble(LireData["Salaire"]);
                    e.Commission = Convert.ToDouble(LireData["Commission"]);
                    //e.Num_Dept = Convert.ToInt32(LireData["Num_Dept"]);

                    listt.Add(e.ToString());

                }

            }
            else
            {
                MessageBox.Show("No rows found");
            }

            LireData.Close();

            Connexion.Close();

            return listt;
        }

        public List<Employe> ListeObjet()
        {
            List<Employe> ListeE = new List<Employe>();
            Employe Ep = new Employe();

            //on crée OpenFileDialog
            Microsoft.Win32.OpenFileDialog Ofd = new Microsoft.Win32.OpenFileDialog();

            //extension par defaut des fichiers  
            Ofd.DefaultExt = ".xml";
            Ofd.Filter = "Text documents (.xml)|*.xml";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = Ofd.ShowDialog();

            //si le fichier existe
            if (result == true)
            {
                //on ouvre le document
                string CheminFichier = Ofd.FileName;//chemin et nom du fichier 

                Connexion.Open();

                SqlCommand TousLesEmployes = new SqlCommand("select * from Emp", Connexion);
                SqlDataReader Resultat = TousLesEmployes.ExecuteReader();

                while (Resultat.Read())
                {
                    Ep.Matricule = Convert.ToString(Resultat["Matricule"]);
                    Ep.Nom = Convert.ToString(Resultat["Nom"]);
                    Ep.Prenom = Convert.ToString(Resultat["Prenom"]);
                    Ep.Salaire = Convert.ToDouble(Resultat["Salaire"]);
                    Ep.Commission = Convert.ToDouble(Resultat["Commission"]);
                    //Ep.Num_Dept = Convert.ToInt32(Resultat["Num_Dept"]);

                    ListeE.Add(Ep);
                }
                Resultat.Close();

                XmlSerializer Xmls = new XmlSerializer(typeof(List<Employe>));

                Stream stream = File.OpenWrite(CheminFichier); //copie dans le fichier

                Xmls.Serialize(stream, ListeE);//on serialize
                stream.Close();//on ferme

                //crée un fichier supplémentaire en Backup dans Documents
                Stream stream2 = File.OpenWrite("C:\\Users\\ludo\\Documents\\MonText" + DateTime.Now.ToString("yyyyMMdd") + ".xml");
                Xmls.Serialize(stream2, ListeE);
                stream2.Close();

                /*
                StreamReader Sreader = new StreamReader(CheminFichier); //Initialise une nouvelle 
                                                                 //instance de StreamReader
                var Input = Xmls.Deserialize(Sreader);//on deserialize
                dataGridView.DataSource = Input; //résultat dans le dataGridview (tableau) 
                */

                Connexion.Close();
            }

            return ListeE;
        }

    }
}
