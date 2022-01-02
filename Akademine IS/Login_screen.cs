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
        public string poUserId = "";
        public string poAsmuoId = "";
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
            if (!usp_Login.ParamByName("@poUserId").Value.ToString().Equals("")) ;
            {
                poUserId = usp_Login.ParamByName("@poUserId").Value.ToString();
            }
            if (!usp_Login.ParamByName("@poAsmuoId").Value.ToString().Equals("")) ;
            {
                poAsmuoId = usp_Login.ParamByName("@poAsmuoId").Value.ToString();

            }

            switch (poValue)
            {
                case "2": //Super adminas
                    Admin_MainMenu mm = new Admin_MainMenu(DataHandler, poValue, poUser);
                    mm.ShowDialog();
                    break;
                case "4": //Destytojas
                    Destytojai_Menu dm = new Destytojai_Menu(DataHandler, poValue, poUser, Convert.ToInt32(poUserId), Convert.ToInt32(poAsmuoId));
                    dm.ShowDialog();
                    break;
                case "5": //Studentas
                    StudentoMenu sm = new StudentoMenu(DataHandler, poValue, poUser, Convert.ToInt32(poUserId), Convert.ToInt32(poAsmuoId));
                    sm.ShowDialog();
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
                if (!usp_Login.ParamByName("@poUserId").Value.ToString().Equals("")) ;
                {
                    poUserId = usp_Login.ParamByName("@poUserId").Value.ToString();
                }
                if (!usp_Login.ParamByName("@poAsmuoId").Value.ToString().Equals("")) ;
                {
                    poAsmuoId = usp_Login.ParamByName("@poAsmuoId").Value.ToString();

                }


                switch (poValue)
                {
                    case "2": //Super adminas
                        Admin_MainMenu mm = new Admin_MainMenu(DataHandler, poValue, poUser);
                        mm.ShowDialog();
                        break;
                    case "4": //Destytojas
                        Destytojai_Menu dm = new Destytojai_Menu(DataHandler, poValue, poUser, Convert.ToInt32(poUserId), Convert.ToInt32(poAsmuoId));
                        dm.ShowDialog();
                        break;
                    case "5": //Studentas
                        StudentoMenu sm = new StudentoMenu(DataHandler, poValue, poUser, Convert.ToInt32(poUserId), Convert.ToInt32(poAsmuoId));
                        sm.ShowDialog();
                        break;
                }

            }
        }
    }
    
}
