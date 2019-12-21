using System;
using System.Windows.Forms;
using System.IO;
using SocialModelRebuild.Models;


namespace SocialModelRebuild
{
    public partial class FormSave : Form
    {
        private CellModel cellModel;

        public FormSave(CellModel cellModel)
        {
            InitializeComponent();
            this.cellModel = cellModel;
            this.textBoxModelName.Text = cellModel.Name;
            this.label1.Text = "_" + cellModel.Iteration + "_" + cellModel.Guid;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            cellModel.Name = this.textBoxModelName.Text;

            var str = new SavingCellModel().SaveCellModel(cellModel);
            var fileName = cellModel.Name + "_" + cellModel.Iteration + "_" + this.cellModel.Guid + ".cells";

            var dir = Environment.CurrentDirectory + @"/SavedModels";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            try
            {
                File.WriteAllText(Environment.CurrentDirectory + @"/SavedModels/" + fileName, str);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно записать файл! Попробуйте переименовать или освободить память");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
