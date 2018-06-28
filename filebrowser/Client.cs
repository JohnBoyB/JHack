﻿/**
 * 
 * This is the main form where the user can encrypt and decrypt files.
 * 
 * Client() Initialize Form Component 
 *
 * PopulateTreeView() Initialize TreeView on the left side of the application
 *
 * GetDirectories() get all directories from the main folder
 * 
 * but_treeView1_NodeMouseClick() allow to mark objects(folder, files) in the TreeView
 *
 * but_encrypt_Click() button which encrypts file and saves to the folder "encrypted" in the main folder.
 *
 * but_decrypt_Click() button which decrypts file and saves to the folder "decrypted" in the main folder.
 *
 **/

using System;
using System.Windows.Forms;
using System.IO;

namespace filebrowser
{
    public partial class Client : Form
    {
        private static readonly log4net.ILog log = logHelper.GetLogger();

        //define crypto elements and filesystem options
        crypto crypt = new crypto();
        crypto_symmetric symcrypt = new crypto_symmetric();
        directory checkAndCreateFolder = new directory();

        //Generate the client form, check filesystem and build main componants 
        public Client()
        {
            //check if folders exists if not create them 
            checkAndCreateFolder.checkfilesystem();
            InitializeComponent();
            PopulateTreeView();
        }

        //create treeview for folder overview in main folder
        private void PopulateTreeView()
        {
            try
            {
                TreeNode rootNode;
                DirectoryInfo info = new DirectoryInfo(@"C:\crypto");
                if (info.Exists)
                {
                    rootNode = new TreeNode(info.Name);
                    rootNode.Tag = info;
                    GetDirectories(info.GetDirectories(), rootNode);
                    treeView1.Nodes.Add(rootNode);
                }
                log.Info("Treeview initialized");
            }
            catch
            {
                log.Fatal("Initializing Treeview failed");
            }
        }

        //fill folder structer in treeview on the left side
        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            try
            {
                TreeNode aNode;
                DirectoryInfo[] subSubDirs;
                foreach (DirectoryInfo subDir in subDirs)
                {
                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    //Tag folder with a folder image, files with nothing
                    aNode.ImageKey = "folder";
                    subSubDirs = subDir.GetDirectories();
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories(subSubDirs, aNode);
                    }
                    nodeToAddTo.Nodes.Add(aNode);
                }
                log.Info("Got all directories from main folder");
            }
            catch
            {
                log.Error("loading directories from main folder failed");
            }
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode newSelected = e.Node;
                listView1.Items.Clear();
                DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
                ListViewItem.ListViewSubItem[] subItems;
                ListViewItem item = null;

                foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
                {
                    item = new ListViewItem(dir.Name, 0);
                    subItems = new ListViewItem.ListViewSubItem[]
                              {new ListViewItem.ListViewSubItem(item, "Directory"),
                   new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }
                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                              { new ListViewItem.ListViewSubItem(item, "File"),
                   new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }
            catch
            {
                log.Error("ListViewItem failed");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }

        //encrypt files
        private void but_encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count != 0)
                {
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {
                        symcrypt.symetrEncrypt(@"C:\crypto\decrypted\" + item.Text, @"C:\crypto\encrypted\" + item.Text);
                        File.Delete(@"C:\crypto\decrypted\" + item.Text);
                    }
                    MessageBox.Show("Encrypt File", "Success");
                }
                else
                {
                    MessageBox.Show("No file selected", "error");
                }
                log.Info("Encryption completed");
            }
            catch
            {
                log.Fatal("Encryption failed");
            }
        }

        //decrypt files
        private void but_decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count != 0)
                {
                    foreach (ListViewItem item in listView1.SelectedItems)
                {
                    symcrypt.symetrDecrypt(@"C:\crypto\encrypted\" + item.Text, @"C:\crypto\decrypted\" + item.Text);
                    File.Delete(@"C:\crypto\encrypted\" + item.Text);
                }
                MessageBox.Show("Decrypt File", "Success");
                }
                else
                {
                    MessageBox.Show("No file selected", "error");
                }

                log.Info("Decryption completed");
            }
            catch
            {
                log.Fatal("Decryption failed");
            }
        }

        private void Share_Click(object sender, EventArgs e)
        {
            Sharing Form1 = new Sharing();
            Form1.ShowDialog();
        }
    }
}
