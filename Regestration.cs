/**
 * 
 * This class send regestartion details like username, password & email to WebAPI 
 * 
 * Regestration() constructor
 * 
 * but_Regestration_Click() send regestration details to the WebAPI and give an error if not every field is filed
 * If the regestration was successfully the window will be closed and the main window will be open
 * If the regestration was not successfully the user recives an error message.
 **/

using System;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace filebrowser
{
    public partial class Regestration : Form
    {
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
                        //Create more than one error message
                        MessageBox.Show("There was an error");
                        //ToDo Logging
                        return;
                    }

                    Globals.LoggedInUser = user;
                    MessageBox.Show("Registration successful");
                    FormLogin login = new FormLogin();
                    login.Show();
                    this.Hide();
                    //ToDo Logging
                }
                else
                {
                    MessageBox.Show("Please file all fileds", "Error");
                    //ToDo Logging
                }
            }

            catch
            {
                //ToDo Logging
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            lblUsername.Text = "Username";  
            lblPassword.Text = "Password"; 
            lblEmail.Text = "E-Mail";
            butRegestration.Text = "Registration"; 
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblUsername.Text = "имя пользователя";   
            lblPassword.Text = "шифр"; ;
            lblEmail.Text = "мейл"; 
            butRegestration.Text = "регистра́ция"; 
        }

        private void germanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblUsername.Text = "Benutzername";   
            lblPassword.Text = "Passwort";
            lblEmail.Text = "E-Mail"; 
            butRegestration.Text = "Registrieren"; 
        }
    } 
}
