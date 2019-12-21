using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SocialModelRebuild.Models;

namespace SocialModelRebuild
{
    public partial class FormLoad : Form
    {
        public delegate void ModelLoadedHandler(CellModel cellModel);
        public event ModelLoadedHandler ModelLoaded;

        string path = Environment.CurrentDirectory + @"/SavedModels";
        List<string> allFiles;
        int page = 0;

        public FormLoad(CellModel cellModel)
        {
            InitializeComponent();
            if (Directory.Exists(path))
            {
                this.allFiles = Directory.EnumerateFiles(path).ToList();
            }
            else return;



            for (int i = 10 * page; i < Math.Min(allFiles.Count, 10); i++)
            {
                var button = new Button();

                button.Location = new System.Drawing.Point(0, (i % 10) * 40 + 5);
                button.Text = new FileInfo(allFiles[i]).Name;
                button.Height = 40;
                button.Width = this.Width - 5;
                button.Click += this.buttonLoad_Click;
                this.Controls.Add(button);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var str = File.ReadAllText(path + "//" +((Button)sender).Text);
            var loadCellModel = new SavingCellModel().LoadCellModel(str);

            ModelLoaded?.Invoke(loadCellModel);
        }
    }
}
