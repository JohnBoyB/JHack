namespace filebrowser
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txb_Username = new System.Windows.Forms.TextBox();
            this.txb_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.but_Login = new System.Windows.Forms.Button();
            this.link_Regestartion = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txb_Username
            // 
            resources.ApplyResources(this.txb_Username, "txb_Username");
            this.txb_Username.Name = "txb_Username";
            // 
            // txb_Password
            // 
            resources.ApplyResources(this.txb_Password, "txb_Password");
            this.txb_Password.Name = "txb_Password";
            this.txb_Password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // but_Login
            // 
            resources.ApplyResources(this.but_Login, "but_Login");
            this.but_Login.Name = "but_Login";
            this.but_Login.UseVisualStyleBackColor = true;
            this.but_Login.Click += new System.EventHandler(this.but_Login_Click);
            // 
            // link_Regestartion
            // 
            resources.ApplyResources(this.link_Regestartion, "link_Regestartion");
            this.link_Regestartion.Name = "link_Regestartion";
            this.link_Regestartion.TabStop = true;
            this.link_Regestartion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_Regestartion_LinkClicked);
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.link_Regestartion);
            this.Controls.Add(this.but_Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_Password);
            this.Controls.Add(this.txb_Username);
            this.Name = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_Username;
        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_Login;
        private System.Windows.Forms.LinkLabel link_Regestartion;
    }
}