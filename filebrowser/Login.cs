/**
 * 
 * This class handles the login functions in the login form including the button click and the registration click
 * As a testing scenario we create a easy offline login which is called username = "1" & password = "1"
 * This login function is activated if the compile option is Debug.
 * If the compile option is Release the "easy" login will be deactivated and the secure login over the WebAPI will be activated. 
 * The "easy" login is not documented in this comments and will be deleted after the server is implemented.
 * The "easy" login begins at the #if DEBUG statment and ends at the #else statment.
 * 
 * but_Login_Click() takes username and password from the textboxes txb_username and txb_password and send this information over the WebAPI to check the credentials.
 * If the Login is correct the system checks the folder structure, creates this if it not exists, and generates a rsa keypair if the ppk and pub does not exist.
 * After success login the window will be closed and the client form will be showen.
         * @param string username
         * @param string password
         * @file COMPUTERNAME.ppk
         * @file COMPUTERNAME.pub
 * 
 *  link_Regestartion_LinkClicked() open the regestration form and close active form
 *
 *  link_Regestartion_LinkClicked() open the regestration form and close active form
         * @param string 
 *
 **/

using System;
using System.Windows.Forms;
using System.IO;

namespace filebrowser
{
    public partial class Login : Form
    {
        private static readonly log4net.ILog log = logHelper.GetLogger();

        public Login()
        {
            InitializeComponent();
        }

        //User login and generating of new rsa keypair if not exists
        private void but_Login_Click(object sender, EventArgs e)
        {
            //define local variables from the user inputs 
            string username = txb_Username.Text;
            string password = txb_Password.Text;

            //if debug mode you can login with username 1 and password 1
#if DEBUG
            // creating an easy login for testing solong no webAPI exists
            Login login = new Login("jonas.becher@hs-niederrhein.de", "test123");
            //check if eligible to be logged in 
            if (login.IsLoggedIn(username, password))
            {
                Client Form1 = new Client();
                this.Hide();
                Form1.ShowDialog();
                this.Close();
            }

            //if release mode use AuthO with JASON API to connect to the server and recieve a jwt token
#else

            ApiLoginOperations ops = new ApiLoginOperations();
            User user = ops.AuthenticateUser(username, password);
            if (user == null)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }

            Globals.LoggedInUser = user;
            MessageBox.Show("Login successful");
            Client Form1 = new Client();
            this.Hide();
            Form1.ShowDialog();
            this.Close();

            log.Info("asymKeys generated");
#endif
        }

        //Open registration form
        private void link_Regestartion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Regestration reg = new Regestration();
            this.Hide();
            reg.ShowDialog();
            this.Close();
        }

        //Login Methods and decarations for offline or debug mode
        //you can use this login methods if you have a application without an online authentication 
#if DEBUG
        //declare properties 
        public string Username { get; set; }
        public string Userpassword { get; set; }

        //intialise  
        public Login(string user, string pass)
        {
            this.Username = user;
            this.Userpassword = pass;
        }
        //clear user inputs 
        private void ClearTexts(string user, string pass)
        {
            user = String.Empty;
            pass = String.Empty;
        }
        //method to check if eligible to be logged in 
        internal bool IsLoggedIn(string user, string pass)
        {
            //check user name empty 
            if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Enter the user name and password!");
                return false;

            }

            //check user name is correct 
            else
            {
                if (Username != user)
                {
                    MessageBox.Show("User name is incorrect!");
                    ClearTexts(user, pass);
                    return false;
                }
                //check password is empty 
                else
                {
                    //check password is correct 
                    if (Userpassword != pass)
                    {
                        MessageBox.Show("Password is incorrect");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblUsername.Text = "Username";
            lblPassword.Text = "Password";
            butLogin.Text = "Login";
            butRegistration.Text = "Registration";
        }

        private void germanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblUsername.Text = "Benutzername";
            lblPassword.Text = "Passwort";
            butLogin.Text = "Login";
            butRegistration.Text = "Registrierung";
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblUsername.Text = "имя пользователя";
            lblPassword.Text = "шифр";
            butLogin.Text = "Войти";
            butRegistration.Text = "регистра́ция";
        }
#endif
    }
}
