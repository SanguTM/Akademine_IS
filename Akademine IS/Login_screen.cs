using System;
using System.Windows.Forms;
using System.IO;

namespace Akademine_IS
{
    public partial class Login_screen : Form 
    {
        //static t_DataHandler DataHandler = new t_DataHandler("Data Source = LENOVO; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
        //static t_DataHandler DataHandler = null;
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
            string iniFileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\DB.ini";

            //t_DataHandler DataHandler = new t_DataHandler("Data Source = SANGU-PC; Initial Catalog = AkademineIS; User ID = sa; Password = qwer7894;");
            DataHandler = new t_DataHandler(iniFileName, 1);

            string UserName = UserNameBox.Text;
            string Password = PasswordBox.Text;

            t_StoredProc usp_Login = new t_StoredProc(DataHandler, "usp_Login");
            usp_Login.ParamByName("@piKodas").Value = UserName;
            usp_Login.ParamByName("@piSlaptazodis").Value = Password;
            usp_Login.Execute();

            if (!usp_Login.ParamByName("@poValue").Value.ToString().Equals(""));
            {
                poValue = usp_Login.ParamByName("@poValue").Value.ToString();
        
            }
            if (!usp_Login.ParamByName("@poError").Value.ToString().Equals(""));
            {
                poError = usp_Login.ParamByName("@poError").Value.ToString();

            }
            if (!usp_Login.ParamByName("@poUser").Value.ToString().Equals(""));
            {
                poUser = usp_Login.ParamByName("@poUser").Value.ToString();

            }

            switch (poValue)
            {
                case "2": //Super adminas
                    Admin_MainMenu mm = new Admin_MainMenu(DataHandler, poValue, poUser);
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

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string iniFileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\DB.ini";

                DataHandler = new t_DataHandler(iniFileName, 1);

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
                        Admin_MainMenu mm = new Admin_MainMenu(DataHandler, poValue, poUser);
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
    
}
