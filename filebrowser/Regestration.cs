/**
 * 
 * This class send registartion details username, password & email to WebAPI 
 * 
 * Regestration() constructor
 * 
 * but_Regestration_Click() send registration details to the WebAPI and give an error if not every field is filled
 * If the registration was successful the window will be closed and the main window will be open
 * If the registration was not successful the user recieves an error message.
 **/

using System;
using System.Windows.Forms;

namespace filebrowser
{
    public partial class Regestration : Form
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public Regestration()
        {
            InitializeComponent();
        }

        //register a user over the ApiLoginOperations with username, password & email
        private void but_Regestration_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txb_Username.Text;
                string password = txb_Password.Text;
                string eMail = txb_EMail.Text;

                ApiLoginOperations ops = new ApiLoginOperations();
                User user = ops.RegisterUser(username, password, eMail);
                if (username != String.Empty && password != String.Empty && eMail != String.Empty)
                {
                    if (user == null)
                    {
                        //ToDo Create more than one error message
                        MessageBox.Show("There was an error");
                        log.Error("Registration failed");
                        return;
                    }

                    Globals.LoggedInUser = user;
                    MessageBox.Show("Registration successful");
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                    log.Info("Registration successful");
                }
                else
                {
                    MessageBox.Show("Please fill in all fields", "Error");
                    log.Error("Registration form was not filled in correctly");
                }
            }

            catch
            {
                log.Error("Registration failed");
            }
        }
    }
}
