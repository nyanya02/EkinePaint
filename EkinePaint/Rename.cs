using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace EkinePaint
{
    public partial class Rename : Form
    {

        private string[] fileAll;
        private List<string> fileName = new List<string>();
        private int count;


        public Rename()
        {
            InitializeComponent();
        }

        private void Rename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void buttonFileName_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            string directory = Path.GetDirectoryName(openDialog.FileName);
            fileAll = Directory.GetFiles(directory, "*");

            textBoxFileName.Text = directory;

            count = 0;
            labelNumber.Text = (count + 1).ToString() + "/" + fileAll.Length.ToString();
        }

        private void buttonStart_Click(object sender, System.EventArgs e)
        {
            if (fileAll.Length <= 0)
            {
                MessageBox.Show("ファイルが選択されていません");
                return;
            }


            string extension;
            string directoryName;
            string combineName;

            int num = 0;

            for (int i = 0; i < fileAll.Length; i++)
            {
                string file = Path.GetFileName(fileAll[i]);

                if (Path.GetFileNameWithoutExtension(file).Length > 7)//8桁以上の名前を取得する
                {
                    extension = Path.GetExtension(fileAll[i]);
                    directoryName = Path.GetDirectoryName(fileAll[i]);
                    combineName = Path.Combine(directoryName, count.ToString() + extension);

                    while (File.Exists(combineName))
                    {
                        num++;
                        combineName = Path.Combine(directoryName, num.ToString() + extension);
                    }

                    File.Move(fileAll[i], combineName);
                }

                labelNumber.Text = (count + 1).ToString() + "/" + fileAll.Length;
                Application.DoEvents();
                count++;
            }

            MessageBox.Show("完了");
        }
    }
}
