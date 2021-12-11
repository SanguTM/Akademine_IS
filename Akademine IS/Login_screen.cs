using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Akademine_IS
{
    public partial class Login_screen : Form 
    {

        static t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        public string poValue = "";
        public string poError = "";
        public string poUser = "";

        public Login_screen()
        {

            InitializeComponent();

        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            string UserName = UserNameBox.Text;
            string Password = PasswordBox.Text;

            t_StoredProc usp_Login = new t_StoredProc(DataHandler, "usp_Login");
            usp_Login.ParamByName("@piKodas").Value = UserName;
            usp_Login.ParamByName("@piSlaptazodis").Value = Password;
            usp_Login.Execute();

            if (!usp_Login.ParamByName("@poValue").Value.ToString().Equals("")) ;
            {
                poValue = usp_Login.ParamByName("@poValue").Value.ToString();
        
            }
            if (!usp_Login.ParamByName("@poError").Value.ToString().Equals("")) ;
            {
                poError = usp_Login.ParamByName("@poError").Value.ToString();

            }
            if (!usp_Login.ParamByName("@poUser").Value.ToString().Equals("")) ;
            {
                poUser = usp_Login.ParamByName("@poUser").Value.ToString();

            }

            switch (poValue)
            {
                case "2": //Super adminas
                    Admin_MainMenu mm = new Admin_MainMenu(poValue, poUser);
                    mm.ShowDialog();
                    break;
                case "4": //Destytojas
                   ShowDialog();
                    break;
                case "5": //Studentas
                    ShowDialog();
                    break;
            }

        }
    }
    
}
